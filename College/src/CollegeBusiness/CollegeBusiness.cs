using CollegeBusiness.Model;
using CollegeBusiness.Util;
using CollegeData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace CollegeBusiness
{
    public partial class cBusinessWeb
    {
        public long _userId = (HttpContext.Current.Request.QueryString["user"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["user"])) : 0);

        public ACAD_ACADEMIAS GetAcademy()
        {
            ACAD_ACADEMIAS academia = _context.ACAD_ACADEMIAS
                                               .Where(x => x.CD_ACADEMIA == _enterpriseId &&
                                                         x.FL_ATIVO == true)
                                               .FirstOrDefault();
            return academia;
        }

        public List<cFaq> GetFaq()
        {
            List<cFaq> faq = _context.ACAD_FAQS
                                          .Where(x => x.CD_ACADEMIA == _enterpriseId)
                                          .Select(x => new cFaq()
                                          {
                                              faqId = x.CD_ACADEMIA,
                                              question = x.TX_PERGUNTA,
                                              answer = x.TX_RESPOSTA,
                                              order = x.NR_ORDEM
                                          })
                                          .OrderBy(x => x.order).ToList();
            return faq;
        }

        public List<cCourse> GetMyCourses()
        {
            return _context.ACAD_MATRICULAS.Where(x => x.CD_USUARIO == _userId)
                                           .Select(x => new cCourse()
                                           {
                                               courseId = x.ACAD_CURSOS.CD_CURSO,
                                               name = x.ACAD_CURSOS.NM_CURSO,
                                               summary = x.ACAD_CURSOS.TX_RESUMO,
                                               order = x.ACAD_CURSOS.NR_ORDEM,
                                               performance = 0,
                                               paymentTrasaction = x.TX_TRANSACAO,
                                               codeTrasaction = x.TX_CODIGO,
                                               enrollmentId = x.CD_MATRICULA,
                                               dateEnrollment = x.DT_DATA
                                           })
                                           .OrderByDescending(x => x.dateEnrollment)
                                           .ToList();
        }

        public cUser GetUser()
        {
            long userId = GetLogged().userId;
            return _context.ACAD_USUARIOS
                            .Where(x => x.CD_USUARIO == userId)
                            .Select(x => new cUser()
                                {
                                    userId = x.CD_USUARIO,
                                    enterpriseId = x.CD_ACADEMIA,
                                    name = x.NM_USUARIO,
                                    surname = x.NM_SOBRENOME,
                                    email = x.TX_EMAIL,
                                    tel = x.TX_TELEFONE,
                                    cel = x.TX_CELULAR,
                                    cpf = x.TX_CPF
                                }).FirstOrDefault();
        }

        public List<cArea> GetCourses()
        {
            return _context.ACAD_AREAS
                           .Where(x => x.ACAD_AREAS_CURSOS
                                        .Any(y => y.ACAD_CURSOS.CD_ACADEMIA == _enterpriseId &&
                                                y.ACAD_CURSOS.FL_ATIVO == true))
                                          .Select(x => new cArea()
                                          {
                                              name = x.NM_AREA,
                                              courses = x.ACAD_AREAS_CURSOS
                                                         .Where(y => y.ACAD_CURSOS.FL_ATIVO == true)
                                                         .Select(y => new cCourse()
                                                                  {
                                                                      courseId = y.ACAD_CURSOS.CD_CURSO,
                                                                      name = y.ACAD_CURSOS.NM_CURSO,
                                                                      summary = y.ACAD_CURSOS.TX_RESUMO,
                                                                      order = y.ACAD_CURSOS.NR_ORDEM,
                                                                      description = y.ACAD_CURSOS.TX_DESCRICAO,
                                                                      value = y.ACAD_CURSOS.VL_CURSO
                                                                  })
                                                          .OrderBy(y => y.order).ToList()
                                          })
                                          .OrderBy(x => x.name).ToList();
        }

        public cCourse GetCourse(long courseId)
        {
            long userId = GetLogged().userId;
            return _context.ACAD_CURSOS
                           .Where(x => x.CD_ACADEMIA == _enterpriseId &&
                                       x.CD_CURSO == courseId)
                           .Select(x => new cCourse()
                                        {
                                            courseId = x.CD_CURSO,
                                            name = x.NM_CURSO,
                                            summary = x.TX_RESUMO,
                                            order = x.NR_ORDEM,
                                            description = x.TX_DESCRICAO,
                                            coin = x.TX_MOEDA,
                                            value = x.VL_CURSO,
                                            userId = userId,
                                            enrollmentId = (x.ACAD_MATRICULAS.Count(y => userId == 0 || y.CD_USUARIO == userId) > 0 ? x.ACAD_MATRICULAS.Where(y => userId == 0 || y.CD_USUARIO == userId).FirstOrDefault().CD_MATRICULA : 0)
                                        })
                          .OrderBy(x => x.order)
                          .FirstOrDefault();
        }

        public cCourse GetMyCourse(long courseId, long enrollmentId)
        {
            return GetMyCourseStatus(_userId, courseId, enrollmentId);
        }

        public int GetMyCoursePerformance(long courseId, long enrollmentId)
        {
            cCourse course = GetMyCourseStatus(_userId, courseId, enrollmentId);
            List<cBlock> blocks = course.modules.SelectMany(x => x.blocks).ToList();
            int countBlock = blocks.Count();
            int countBlockFinish = blocks.Where(x => x.status == cEnum.statusBlock.Finalized).Count();

            List<cEnum.statusTest> tests = course.modules.Select(x => x.statusTest).ToList();
            int countTest = tests.Count();
            int countTestFinish = tests.Count(x => x == cEnum.statusTest.Okay);
            return ((countBlockFinish + (countTestFinish * 2)) * 100 / (countBlock + (countTest * 2)));
        }

        public cCourse GetMyCourseStatus(long userId, long courseId, long enrollmentId)
        {
            cCourse course = _context.ACAD_CURSOS.Include("ACAD_MODULOS")
                                       .Where(x => x.CD_ACADEMIA == _enterpriseId &&
                                                   x.CD_CURSO == courseId)
                                       .Select(x => new cCourse()
                                       {
                                           courseId = x.CD_CURSO,
                                           name = x.NM_CURSO,
                                           order = x.NR_ORDEM,
                                           modules = x.ACAD_MODULOS.Select(y => new cModule()
                                                           {
                                                               moduleId = y.CD_MODULO,
                                                               name = y.NM_MODULO,
                                                               page = y.NM_PAGE,
                                                               status = cEnum.statusModule.None,
                                                               order = y.NR_ORDEM,
                                                               blocks = y.ACAD_BLOCOS.Select(w => new cBlock()
                                                                                         {
                                                                                             blockId = w.CD_BLOCO,
                                                                                             moduleId = w.CD_MODULO,
                                                                                             name = w.NM_BLOCO,
                                                                                             page = w.NM_PAGE,
                                                                                             status = cEnum.statusBlock.None,
                                                                                             order = w.NR_ORDEM,
                                                                                             statusExercise = cEnum.statusExercise.None,
                                                                                         }).OrderBy(w => w.order).ToList(),
                                                               resource = y.ACAD_RECURSOS.Select(w => new cResource()
                                                                                         {
                                                                                             resourdeId = w.CD_RECURSO,
                                                                                             name = w.NM_RECURSO,
                                                                                             page = w.NM_PAGE,
                                                                                             status = cEnum.statusResource.None
                                                                                         }).FirstOrDefault(),
                                                               statusTest = cEnum.statusTest.None
                                                           }).OrderBy(y => y.order).ToList()
                                       })
                                      .OrderBy(x => x.order)
                                      .FirstOrDefault();

            cEnum.statusModule prevStatusModule = cEnum.statusModule.None;
            cEnum.statusBlock prevStatusBlock = cEnum.statusBlock.None;
            foreach (cModule module in course.modules)
            {
                if (course.modules.IndexOf(module) == 0 || (prevStatusModule == cEnum.statusModule.Finalized))
                {
                    module.status = cEnum.statusModule.Open;
                    module.resource.status = cEnum.statusResource.Open;
                    module.statusTest = cEnum.statusTest.Close;
                }
                else
                {
                    module.status = cEnum.statusModule.Close;
                    module.resource.status = cEnum.statusResource.Close;
                    module.statusTest = cEnum.statusTest.Close;
                }

                foreach (cBlock block in module.blocks)
                {
                    List<ACAD_USUARIOS_EXERCICIOS> exercises = _context.ACAD_USUARIOS_EXERCICIOS
                                                                       .Where(x => x.ACAD_EXERCICIOS.CD_BLOCO == block.blockId &&
                                                                                   x.CD_USUARIO == userId &&
                                                                                   x.CD_MATRICULA == enrollmentId).ToList();

                    if (exercises.Count() > 0 && (exercises.Where(x => x.TX_RESPOSTA == null).Count() == 0 && exercises.Where(x => x.TX_OBS_CORRECAO == null).Count() == 0))
                    {
                        block.status = cEnum.statusBlock.Finalized;
                        block.statusExercise = cEnum.statusExercise.Revised;
                        prevStatusBlock = cEnum.statusBlock.Finalized;
                        if (module.blocks.IndexOf(block) == module.blocks.Count() - 1)
                        {
                            prevStatusModule = cEnum.statusModule.Finalized;
                        }
                    }
                    else if (exercises.Count() > 0 && exercises.Where(x => x.TX_RESPOSTA == null).Count() == 0)
                    {
                        block.status = cEnum.statusBlock.Waiting;
                        block.statusExercise = cEnum.statusExercise.Correction;
                        prevStatusBlock = cEnum.statusBlock.Waiting;
                    }
                    else if (course.modules.IndexOf(module) == 0 && module.blocks.IndexOf(block) == 0)
                    {
                        block.status = cEnum.statusBlock.Open;
                        block.statusExercise = cEnum.statusExercise.Open;
                        prevStatusBlock = cEnum.statusBlock.Open;
                    }
                    else if (prevStatusBlock == cEnum.statusBlock.Finalized)// && prevStatusModule == cEnum.statusModule.Finalized)
                    {
                        block.status = cEnum.statusBlock.Open;
                        block.statusExercise = cEnum.statusExercise.Open;
                        prevStatusBlock = cEnum.statusBlock.Open;
                        prevStatusModule = cEnum.statusModule.None;
                    }
                    else
                    {
                        block.status = cEnum.statusBlock.Close;
                        block.statusExercise = cEnum.statusExercise.Close;
                        prevStatusBlock = cEnum.statusBlock.Close;
                    }
                }

                if (prevStatusBlock == cEnum.statusBlock.Finalized)
                {
                    List<ACAD_USUARIOS_PROVAS_QUESTOES> tests = _context.ACAD_USUARIOS_PROVAS_QUESTOES
                                                                        .Where(x => x.ACAD_QUESTOES.CD_MODULO == module.moduleId &&
                                                                                    x.CD_USUARIO == userId &&
                                                                                    x.CD_MATRICULA == enrollmentId).ToList();
                    if (tests.Count() > 0)
                    {
                        int nrRevisions = tests.Where(x => x.TX_OBS_CORRECAO == null).Count();

                        TimeSpan span = DateTime.Now.Subtract(tests.Max(x => x.DT_INICIO));
                        if (span.TotalMinutes > Convert.ToInt32(ConfigurationManager.AppSettings["TestTime"]))
                        {
                            module.status = cEnum.statusModule.Open;
                            module.resource.status = cEnum.statusResource.Open;
                            module.statusTest = cEnum.statusTest.Correction;

                            if (nrRevisions == 0)
                            {
                                if ((tests.Count(x => x.FL_ACERTO) * 100 / tests.Count()) >= 80)
                                {
                                    module.status = cEnum.statusModule.Finalized;
                                    module.resource.status = cEnum.statusResource.Open;
                                    module.statusTest = cEnum.statusTest.Okay;
                                    prevStatusModule = cEnum.statusModule.Finalized;
                                }
                                else
                                {
                                    module.status = cEnum.statusModule.Open;
                                    module.resource.status = cEnum.statusResource.Open;
                                    module.statusTest = cEnum.statusTest.Failing;
                                }
                            }
                        }
                        else
                        {
                            module.status = cEnum.statusModule.Open;
                            module.resource.status = cEnum.statusResource.Open;
                            module.statusTest = cEnum.statusTest.Progress;
                        }
                    }
                    else
                    {
                        module.status = cEnum.statusModule.Open;
                        module.resource.status = cEnum.statusResource.Open;
                        module.statusTest = cEnum.statusTest.Open;
                    }
                }
            }

            return course;
        }

        public List<cEvent> GetEvents()
        {
            List<cEvent> events = _context.ACAD_EVENTOS
                                          .Where(x => x.CD_ACADEMIA == _enterpriseId && x.FL_ATIVO == true)
                                          .Select(x => new cEvent()
                                          {
                                              eventId = x.CD_EVENTO,
                                              name = x.NM_EVENTO,
                                              dateInit = x.DT_INICIO,
                                              dateFinish = x.DT_FINAL,
                                              url = x.TX_URL,
                                              description = x.TX_DESCRICAO
                                          })
                                          .OrderByDescending(x => x.dateInit).ToList();
            return events;
        }

        public cEnterprise GetEnterprise()
        {
            ACAD_ACADEMIAS academy = GetAcademy();
            cEnterprise enterprise = new cEnterprise()
            {
                enterpriseId = academy.CD_ACADEMIA,
                description = academy.TX_DESCRICAO,
                email = academy.TX_EMAIL,
                tel = academy.TX_TEL
            };
            return enterprise;
        }

        public List<cTestimonial> GetTestimonials()
        {
            List<cTestimonial> testimonials = _context.ACAD_TESTEMUNHOS
                                                      .Where(x => x.CD_ACADEMIA == _enterpriseId && x.FL_ATIVO == true)
                                                      .Select(x => new cTestimonial()
                                                      {
                                                          testimonialId = x.CD_TESTEMUNHO,
                                                          testimonial = x.TX_TESTEMUNHO,
                                                          autor = x.NM_AUTOR,
                                                          local = x.TX_LOCAL,
                                                      })
                                                      .OrderBy(x => Guid.NewGuid()).ToList();
            return testimonials;
        }

        public List<cBanner> GetBanners()
        {
            List<cBanner> banners = _context.ACAD_BANNERS
                                            .Where(x => x.CD_ACADEMIA == _enterpriseId &&
                                                        x.FL_ATIVO == true &&
                                                        SqlFunctions.GetDate() >= x.DT_INICIO &&
                                                        SqlFunctions.GetDate() <= x.DT_FINAL.Value)
                                            .Select(x => new cBanner()
                                            {
                                                bannerId = x.CD_BANNER,
                                                mainCaption = x.TX_CAPTION,
                                                secondaryCaption = x.TX_CAPTION2
                                            })
                                            .OrderBy(x => Guid.NewGuid()).ToList();
            return banners;
        }

        public cModule GetModule(long moduleId)
        {
            return _context.ACAD_MODULOS
                           .Where(y => y.CD_MODULO == moduleId)
                           .Select(y => new cModule()
                                        {
                                            moduleId = y.CD_MODULO,
                                            name = y.NM_MODULO,
                                            status = cEnum.statusModule.None,
                                            order = y.NR_ORDEM
                                        }).FirstOrDefault();
        }

        public cBlock GetBlock(long moduleId, long blockId)
        {
            return _context.ACAD_BLOCOS
                           .Where(y => y.CD_MODULO == moduleId && y.CD_BLOCO == blockId)
                           .Select(y => new cBlock()
                           {
                               blockId = y.CD_BLOCO,
                               moduleId = y.CD_MODULO,
                               name = y.NM_BLOCO,
                               order = y.NR_ORDEM
                           }).FirstOrDefault();
        }

        public List<cUserExercise> GetExercises(long blockId, long enrollmentId)
        {
            long userId = GetLogged().userId;
            return _context.ACAD_EXERCICIOS
                           .Join(_context.ACAD_USUARIOS_EXERCICIOS, x => x.CD_EXERCICIO, y => y.CD_EXERCICIO, (x, y) => new { block = x.CD_BLOCO, order = x.NR_ORDEM, userExercise = y })
                           .Where(x => x.userExercise.CD_MATRICULA == enrollmentId &&
                                       x.userExercise.CD_USUARIO == userId &&
                                       x.block == blockId)
                           .Select(x => new cUserExercise()
                           {
                               userExerciseId = x.userExercise.CD_USUARIO_EXERCICIO,
                               question = x.userExercise.TX_PERGUNTA,
                               reply = x.userExercise.TX_RESPOSTA,
                               correction = (string.IsNullOrEmpty(x.userExercise.TX_RESPOSTA) ? "" : x.userExercise.TX_OBS_CORRECAO),
                               order = x.order,
                               replyContent = (string.IsNullOrEmpty(x.userExercise.TX_RESPOSTA) ? 0 : 1)
                           })
                           .OrderBy(x => new { x.replyContent, x.order })
                           .ToList();
        }

        public bool SetUserExercise(long userExerciseId, string reply)
        {
            try
            {
                ACAD_USUARIOS_EXERCICIOS userExercise = _context.ACAD_USUARIOS_EXERCICIOS
                                                                .Where(x => x.CD_USUARIO_EXERCICIO == userExerciseId)
                                                                .FirstOrDefault();
                if (userExercise != null)
                {
                    userExercise.TX_RESPOSTA = reply;
                    userExercise.DT_EXERCICIO = DateTime.Now;
                    _context.Entry(userExercise).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public void CreateTest(long moduleId, long enrollmentId)
        {
            long userId = GetLogged().userId;
            List<ACAD_USUARIOS_PROVAS_QUESTOES> questions = _context.ACAD_USUARIOS_PROVAS_QUESTOES
                                                                    .Where(x => x.CD_USUARIO == userId &&
                                                                                x.CD_MATRICULA == enrollmentId &&
                                                                                x.ACAD_QUESTOES.CD_MODULO == moduleId).ToList();

            foreach (ACAD_USUARIOS_PROVAS_QUESTOES item in questions)
            {
                _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            }
            _context.SaveChanges();

            List<ACAD_QUESTOES> newQuestions = _context.ACAD_QUESTOES
                                                       .Where(x => x.CD_MODULO == moduleId)
                                                       .OrderBy(x => Guid.NewGuid())
                                                       .Take(Convert.ToInt32(ConfigurationManager.AppSettings["QuestionsNumber"]))
                                                       .ToList();

            DateTime testDate = DateTime.Now;

            foreach (ACAD_QUESTOES q in newQuestions)
            {
                ACAD_USUARIOS_PROVAS_QUESTOES test = new ACAD_USUARIOS_PROVAS_QUESTOES()
                {
                    CD_USUARIO = userId,
                    CD_MATRICULA = enrollmentId,
                    CD_QUESTAO = q.CD_QUESTAO,
                    DT_INICIO = testDate,
                    TX_PERGUNTA = q.TX_PERGUNTA,
                    TX_GABARITO = q.TX_GABARITO
                };
                _context.Entry(test).State = System.Data.Entity.EntityState.Added;
            }
            _context.SaveChanges();
        }

        public List<cUserTest> GetTests(long moduleId, long enrollmentId)
        {
            long userId = GetLogged().userId;
            List<cUserTest> userTest = _context.ACAD_QUESTOES
                                           .Join(_context.ACAD_USUARIOS_PROVAS_QUESTOES, x => x.CD_QUESTAO, y => y.CD_QUESTAO, (x, y) => new { module = x.CD_MODULO, userTest = y })
                                           .Where(x => x.userTest.CD_MATRICULA == enrollmentId &&
                                                       x.userTest.CD_USUARIO == userId &&
                                                       x.module == moduleId)
                                           .Select(x => new cUserTest()
                                           {
                                               userTestId = x.userTest.CD_PROVA,
                                               question = x.userTest.TX_PERGUNTA,
                                               reply = x.userTest.TX_RESPOSTA,
                                               correction = x.userTest.TX_OBS_CORRECAO,
                                               initDate = x.userTest.DT_INICIO
                                           })
                                           .ToList();
            foreach (cUserTest item in userTest)
            {
                if (DateTime.Now.Subtract(item.initDate).TotalMinutes < Convert.ToInt32(ConfigurationManager.AppSettings["TestTime"]))
                {
                    item.correction = "";
                    item.enabledEdit = true;
                }
            }

            return userTest;
        }

        public bool SetUserTest(long userTestId, string reply)
        {
            try
            {
                ACAD_USUARIOS_PROVAS_QUESTOES userTest = _context.ACAD_USUARIOS_PROVAS_QUESTOES
                                                                 .Where(x => x.CD_PROVA == userTestId)
                                                                 .FirstOrDefault();
                if (userTest != null)
                {
                    userTest.TX_RESPOSTA = reply;
                    _context.Entry(userTest).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public string ToRoman(int number)
        {
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            else if (number >= 900) return "CM" + ToRoman(number - 900);
            else if (number >= 500) return "D" + ToRoman(number - 500);
            else if (number >= 400) return "CD" + ToRoman(number - 400);
            else if (number >= 100) return "C" + ToRoman(number - 100);
            else if (number >= 90) return "XC" + ToRoman(number - 90);
            else if (number >= 50) return "L" + ToRoman(number - 50);
            else if (number >= 40) return "XL" + ToRoman(number - 40);
            else if (number >= 10) return "X" + ToRoman(number - 10);
            else if (number >= 9) return "IX" + ToRoman(number - 9);
            else if (number >= 5) return "V" + ToRoman(number - 5);
            else if (number >= 4) return "IV" + ToRoman(number - 4);
            else if (number >= 1) return "I" + ToRoman(number - 1);
            else return string.Empty;
        }
    }
}
