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
    
    public partial class UsuarioBloco : BaseEntity
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdBloco { get; set; }
    
        public virtual Bloco Bloco { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
