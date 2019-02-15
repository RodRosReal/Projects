﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Diagram
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using Domain.Entities.Relacional;
    
    public partial class PrincipalDBContainer : DbContext
    {
        private static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings["SIS_Conexao"]);
        public PrincipalDBContainer()
            : base("metadata=res://*/Infrastructure.Diagram.PrincipalDB.csdl|res://*/Infrastructure.Diagram.PrincipalDB.ssdl|res://*/Infrastructure.Diagram.PrincipalDB.msl;provider=System.Data.SqlClient;provider connection string=\"data source=" + builder.DataSource + ";initial catalog=" + builder.InitialCatalog + ";" + (builder.IntegratedSecurity ? "integrated security=True;" : "User ID=" + builder.UserID + ";Password=" + builder.Password + ";") + "MultipleActiveResultSets=True;App=EntityFramework\"")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FoccoWebApiConfiguracao> FoccoWebApiConfiguracao { get; set; }
        public virtual DbSet<FoccoWebApiProduto> FoccoWebApiProduto { get; set; }
        public virtual DbSet<FoccoWebApiClienteProduto> FoccoWebApiClienteProduto { get; set; }
        public virtual DbSet<FoccoWebApiFormaPagamento> FoccoWebApiFormaPagamento { get; set; }
        public virtual DbSet<FoccoWebApiPrazo> FoccoWebApiPrazo { get; set; }
    }
}