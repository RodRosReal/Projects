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
    
    public partial class FoccoWebApiProduto
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Fornecedor { get; set; }
    }
}
