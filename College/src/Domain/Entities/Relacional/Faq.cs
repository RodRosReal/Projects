//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entities.Relacional
{
    using Domain.Core;
    using System;
    using System.Collections.Generic;
    
    public partial class Faq : BaseEntity
    {
        public int Id { get; set; }
        public int IdAcademia { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }
    
        public virtual Academia Academia { get; set; }
    }
}
