using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.ValueObjects.Base
{
    [DataContract]
    public class Budget
    {
        [JsonProperty(PropertyName = "IdOrcamento")]
        public int IdOrcamento { get; set; }
        [JsonProperty(PropertyName = "CodigoEmpresa")]
        public int CodigoEmpresa { get; set; }
        [JsonProperty(PropertyName = "Uf")]
        public string Uf { get; set; }
        [JsonProperty(PropertyName = "ValorLiquido")]
        public decimal ValorLiquido { get; set; }
        [JsonProperty(PropertyName = "ValorIpi")]
        public decimal ValorIpi { get; set; }
        [JsonProperty(PropertyName = "ValorSubIcms")]
        public decimal ValorSubIcms { get; set; }

        [JsonProperty(PropertyName = "Itens")]
        public List<BudgetItem> Items { get; set; }
    }

    [DataContract]
    public class BudgetItem
    {
        [JsonProperty(PropertyName = "IdOrcamento")]
        public int BudgetId { get; set; }
        [JsonProperty(PropertyName = "CodigoEmpresa")]
        public int CodigoEmpresa { get; set; }
        [JsonProperty(PropertyName = "Uf")]
        public string Uf { get; set; }
        [JsonProperty(PropertyName = "IdItem")]
        public int IdItem { get; set; }
        [JsonProperty(PropertyName = "ValorLiquido")]
        public decimal ValorLiquido { get; set; }
        [JsonProperty(PropertyName = "ValorIpi")]
        public decimal ValorIpi { get; set; }
        [JsonProperty(PropertyName = "ValorSubIcms")]
        public decimal ValorSubIcms { get; set; }

        [JsonIgnore]
        public string CodigoItem { get; set; }
    }
}
