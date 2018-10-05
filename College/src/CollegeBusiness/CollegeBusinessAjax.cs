
using CollegeBusiness.Model;
using CollegeBusiness.Util;
using CollegeData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CollegeBusiness
{
    public static class cBusinessAjax
    {
        public static CollegeEntities _context;

        public static string Login(string email, string password)
        {
            HttpContext.Current.Session["USER"] = null;
            long enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                _context = cDataContextFactory.GetDataContext();
                cLogin user = _context.ACAD_USUARIOS.Where(x => x.CD_ACADEMIA == enterpriseId &&
                                                                x.TX_EMAIL == email &&
                                                                x.TX_SENHA == password &&
                                                                x.FL_ATIVO == true)
                                                      .Select(x => new cLogin()
                                                          {
                                                              enterpriseId = x.CD_ACADEMIA,
                                                              userId = x.CD_USUARIO,
                                                              userName = x.NM_USUARIO,
                                                              email = x.TX_EMAIL,
                                                              teacher = x.ACAD_ACADEMIAS.ACAD_CURSOS
                                                                                        .Where(y=>y.CD_PROFESSOR == x.CD_USUARIO)
                                                                                        .Select(y => new cTeacher()
                                                                                        {
                                                                                            courseId = SqlFunctions.StringConvert((double)y.CD_CURSO),
                                                                                            couseName = y.NM_CURSO 
                                                                                        })
                                                                                        .ToList()
                                                          }).FirstOrDefault();

                if (user != null)
                {
                    foreach (cTeacher item in user.teacher)
                    {
                        item.courseId = cWebCrypto.Encrypt(item.courseId.Trim());
                    }
                    HttpContext.Current.Session["USER"] = user;
                    return cWebCrypto.Encrypt(user.userId.ToString());
                }
            }
            return "";
        }

        public static cLogin GetLogged()
        {
            cLogin user = new cLogin();
            if (HttpContext.Current.Session["USER"] != null)
            {
                return (cLogin)HttpContext.Current.Session["USER"];
            }
            return user;
        }

        public static bool Forgot(cEmail cEmail)
        {
            try
            {
                long enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));
                _context = cDataContextFactory.GetDataContext();
                ACAD_USUARIOS user = _context.ACAD_USUARIOS.Include("ACAD_ACADEMIAS")
                                                .Where(x => x.CD_ACADEMIA == enterpriseId &&
                                                            x.TX_EMAIL == cEmail.EmailTo &&
                                                            x.FL_ATIVO == true).FirstOrDefault();

                if (user != null)
                {
                    cEmail.UrlBase = user.ACAD_ACADEMIAS.TX_URL_BASE;
                    cEmail.Url = user.ACAD_ACADEMIAS.TX_URL;
                    cEmail.ForgotPassword = user.TX_SENHA;
                    cEmail.ServerSmtp = user.ACAD_ACADEMIAS.TX_SMTP;
                    cEmail.PortSmtp = user.ACAD_ACADEMIAS.TX_SMTP_PORTA;
                    cEmail.UserSmtp = user.ACAD_ACADEMIAS.TX_EMAIL;
                    cEmail.PasswordSmtp = user.ACAD_ACADEMIAS.TX_SENHA_EMAIL;
                    cEmail.NameTo = user.NM_USUARIO;
                    cEmail.EmailTo = user.TX_EMAIL;
                    cEmail.NameFrom = user.ACAD_ACADEMIAS.NM_ACADEMIA;
                    cEmail.EmailFrom = user.ACAD_ACADEMIAS.TX_EMAIL;
                    if (SendEmail(cEmail, cEnum.TypeFile.EmailForgotPassword))
                    {
                        return true;
                    };

                }
            }
            catch
            {
            }
            return false;
        }

        public static bool SendEmail(cEmail cEmail, cEnum.TypeFile emailType)
        {
            cEmailMessage emailMessage = new cEmailMessage();
            long enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));

            try
            {
                string body = "";
                if (emailType == cEnum.TypeFile.EmailForgotPassword)
                {
                    string bodyTemplate = GetTemplate(emailType, cEmail.UrlBase + "assets/email/");
                    body = bodyTemplate.Replace("<!--@LINKLOGO@-->", cEmail.Url);
                    body = body.Replace("<!--@LOGO@-->", cEmail.UrlBase + "assets/" + enterpriseId.ToString() + "/logo.png ");
                    body = body.Replace("<!--@USER@-->", cEmail.NameTo);
                    body = body.Replace("<!--@EMAIL@-->", cEmail.EmailTo);
                    body = body.Replace("<!--@PASSWORD@-->", cEmail.ForgotPassword);
                    cEmail.Subject = "Solicitação de Senha";
                    cEmail.Message = body;
                }
                else if (emailType == cEnum.TypeFile.EmailContact)
                {
                    string bodyTemplate = GetTemplate(emailType, cEmail.UrlBase + "assets/email/");
                    body = bodyTemplate.Replace("<!--@LINKLOGO@-->", cEmail.Url);
                    body = body.Replace("<!--@LOGO@-->", cEmail.UrlBase + "assets/" + enterpriseId.ToString() + "/logo.png ");
                    body = body.Replace("<!--@NAME@-->", cEmail.NameReply);
                    body = body.Replace("<!--@EMAIL@-->", cEmail.EmailReply);
                    body = body.Replace("<!--@MESSAGE@-->", cEmail.ContactMessage);
                    cEmail.Subject = "Contato";
                    cEmail.Message = body;
                }

                emailMessage.SendEmail(cEmail);
                return true;
            }
            catch
            {
            }
            return false;
        }

        public static string GetTemplate(cEnum.TypeFile type, string url)
        {
            try
            {
                string urlBobyConfirmacao = null;
                HttpWebRequest requestBodyConfirm = null;
                HttpWebResponse responseBodyConfirm = null;
                Encoding codificacao = Encoding.UTF7;
                System.IO.StreamReader streamRetorno = null;
                string bodyConfirm = "vazio";
                if (type == cEnum.TypeFile.EmailForgotPassword)
                {
                    urlBobyConfirmacao = url;
                    urlBobyConfirmacao += "forgot.html";
                }
                else if (type == cEnum.TypeFile.EmailContact)
                {
                    urlBobyConfirmacao = url;
                    urlBobyConfirmacao += "contact.html";
                }
                requestBodyConfirm = (HttpWebRequest)WebRequest.Create(urlBobyConfirmacao);
                responseBodyConfirm = (HttpWebResponse)requestBodyConfirm.GetResponse();
                streamRetorno = new System.IO.StreamReader(responseBodyConfirm.GetResponseStream(), codificacao);
                bodyConfirm = streamRetorno.ReadToEnd();
                responseBodyConfirm.Close();
                return bodyConfirm;
            }
            catch
            {

            }
            return "";
        }

        public static string SetUser(cUser cUser)
        {
            long enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));
            long userId = GetLogged().userId;
            _context = cDataContextFactory.GetDataContext();

            if (_context.ACAD_USUARIOS.Where(x => x.CD_ACADEMIA == enterpriseId &&
                                                x.TX_EMAIL == cUser.email &&
                                                (userId == 0 || x.CD_USUARIO != userId)).Count() > 0)
            {
                return "-1";
            }
            ACAD_USUARIOS user = new ACAD_USUARIOS();
            if (userId > 0)
                user = _context.ACAD_USUARIOS.Where(x => x.CD_USUARIO == userId).FirstOrDefault();

            user.CD_ACADEMIA = enterpriseId;
            user.NM_USUARIO = cUser.name;
            user.NM_SOBRENOME = cUser.surname;
            user.TX_EMAIL = cUser.email;
            user.TX_TELEFONE = cUser.tel;
            user.TX_CELULAR = cUser.cel;
            user.TX_CPF = cUser.cpf;
            if (!string.IsNullOrEmpty(cUser.password))
                user.TX_SENHA = cUser.password;
            user.TX_IP = cUser.ip;
            user.FL_ATIVO = true;

            if (userId == 0)
            {
                user.DT_DATA = DateTime.Now;
                _context.Entry(user).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();

            return cWebCrypto.Encrypt(user.CD_USUARIO.ToString());
        }

        public static bool SendContact(string name, string email, string message)
        {
            try
            {
                long enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));
                _context = cDataContextFactory.GetDataContext();
                ACAD_ACADEMIAS ac = _context.ACAD_ACADEMIAS
                                            .Where(x => x.CD_ACADEMIA == enterpriseId).FirstOrDefault();
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(message))
                {
                    cEmail cemail = new cEmail()
                    {
                        UrlBase = ac.TX_URL_BASE,
                        Url = ac.TX_URL,
                        ServerSmtp = ac.TX_SMTP,
                        PortSmtp = ac.TX_SMTP_PORTA,
                        UserSmtp = ac.TX_EMAIL,
                        PasswordSmtp = ac.TX_SENHA_EMAIL,
                        NameTo = ac.NM_ACADEMIA,
                        EmailTo = ac.TX_EMAIL,
                        NameFrom = name,
                        EmailFrom = ac.TX_EMAIL,
                        NameReply = name,
                        EmailReply = email,
                        ContactMessage = message
                    };

                    if (SendEmail(cemail, cEnum.TypeFile.EmailContact))
                    {
                        return true;
                    };
                }
            }
            catch
            {
            }
            return false;
        }

        public static bool AjaxSendCode(string code, string enrollment, string course)
        {
            try
            {
                long courseId = Convert.ToInt64(cWebCrypto.Decrypt(course));
                long enrollmentId = Convert.ToInt64(cWebCrypto.Decrypt(enrollment));
                long userId = GetLogged().userId;
                _context = cDataContextFactory.GetDataContext();

                Guid guidCode = new Guid(code);
                ACAD_CODIGOS cod = _context.ACAD_CODIGOS.Where(x => x.CD_CURSO == courseId &&
                                                                    x.CD_CODIGO == guidCode &&
                                                                    x.FL_ATIVO == true && x.DT_DATA == null).FirstOrDefault();
                if (cod != null)
                {
                    cod.DT_DATA = DateTime.Now;
                    _context.Entry(cod).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();

                    ACAD_MATRICULAS enroll = _context.ACAD_MATRICULAS.Where(x => x.CD_CURSO == courseId &&
                                                                                   x.CD_USUARIO == userId &&
                                                                                   x.CD_MATRICULA == enrollmentId)
                                                                     .FirstOrDefault();
                    if (enroll != null)
                    {
                        enroll.TX_CODIGO = code;
                        _context.Entry(enroll).State = System.Data.Entity.EntityState.Modified;
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        public static bool AjaxSetEnrollment()
        {
            try
            {
                long userId = GetLogged().userId;
                long courseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["c"]));
                _context = cDataContextFactory.GetDataContext();

                ACAD_MATRICULAS enrollment = _context.ACAD_MATRICULAS.Where(x => x.CD_CURSO == courseId &&
                                                                    x.CD_USUARIO == userId).FirstOrDefault();
                if (enrollment == null)
                {
                    ACAD_MATRICULAS enroll = new ACAD_MATRICULAS()
                    {
                        CD_USUARIO = userId,
                        CD_CURSO = courseId,
                        DT_DATA = DateTime.Now
                    };
                    _context.Entry(enroll).State = System.Data.Entity.EntityState.Added;
                    _context.SaveChanges();

                    List<ACAD_BLOCOS> blocks = _context.ACAD_BLOCOS.Where(x => x.ACAD_MODULOS.CD_CURSO == courseId).ToList();

                    foreach (ACAD_BLOCOS block in blocks)
                    {
                        ACAD_USUARIOS_BLOCOS userBlocks = new ACAD_USUARIOS_BLOCOS()
                        {
                            CD_BLOCO = block.CD_BLOCO,
                            CD_USUARIO = userId
                        };
                        _context.Entry(userBlocks).State = System.Data.Entity.EntityState.Added;

                        List<ACAD_EXERCICIOS> exercises = _context.ACAD_EXERCICIOS.Where(x => x.CD_BLOCO == block.CD_BLOCO).ToList();

                        foreach (ACAD_EXERCICIOS item in exercises)
                        {
                            ACAD_USUARIOS_EXERCICIOS userExercise = new ACAD_USUARIOS_EXERCICIOS()
                            {
                                CD_EXERCICIO = item.CD_EXERCICIO,
                                CD_USUARIO = userId,
                                CD_MATRICULA = enroll.CD_MATRICULA,
                                TX_PERGUNTA = item.TX_PERGUNTA,
                                TX_OBS_CORRECAO = item.TX_GABARITO,
                                DT_EXERCICIO = DateTime.Now
                            };
                            _context.Entry(userExercise).State = System.Data.Entity.EntityState.Added;
                        }
                        _context.SaveChanges();
                    }                    
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
