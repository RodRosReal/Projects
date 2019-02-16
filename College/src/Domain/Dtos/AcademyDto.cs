using Domain.Core;
using System;
using System.Collections.Generic;

namespace Domain.Dto
{
    public class AcademyDto: IDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string SenhaEmail { get; set; }
        public string Smtp { get; set; }
        public int SmtpPorta { get; set; }
        public string UrlBase { get; set; }
        public string Url { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaRobots { get; set; }
        public string MetaGoogleBot { get; set; }
        public string MetaGenerator { get; set; }
        public string MetaRevisiteAfter { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
