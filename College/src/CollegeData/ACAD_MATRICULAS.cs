//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACAD_MATRICULAS
    {
        public ACAD_MATRICULAS()
        {
            this.ACAD_USUARIOS_EXERCICIOS = new HashSet<ACAD_USUARIOS_EXERCICIOS>();
            this.ACAD_USUARIOS_PROVAS_QUESTOES = new HashSet<ACAD_USUARIOS_PROVAS_QUESTOES>();
        }
    
        public long CD_MATRICULA { get; set; }
        public long CD_USUARIO { get; set; }
        public long CD_CURSO { get; set; }
        public string TX_CODIGO { get; set; }
        public string TX_TRANSACAO { get; set; }
        public System.DateTime DT_DATA { get; set; }
    
        public virtual ACAD_CURSOS ACAD_CURSOS { get; set; }
        public virtual ACAD_USUARIOS ACAD_USUARIOS { get; set; }
        public virtual ICollection<ACAD_USUARIOS_EXERCICIOS> ACAD_USUARIOS_EXERCICIOS { get; set; }
        public virtual ICollection<ACAD_USUARIOS_PROVAS_QUESTOES> ACAD_USUARIOS_PROVAS_QUESTOES { get; set; }
    }
}