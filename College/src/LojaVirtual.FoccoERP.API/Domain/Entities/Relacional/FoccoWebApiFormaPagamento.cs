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
    using System;
    using System.Collections.Generic;
    
    public partial class FoccoWebApiFormaPagamento
    {
        public int Id { get; set; }
        public int IdForma { get; set; }
        public int CodigoForma { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
