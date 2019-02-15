using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.ValueObjects
{
    [DataContract]
    public class CreateBudgetItemResponse
    {
        [JsonProperty(PropertyName = "Value")]
        public List<BudgetItem> Rows { get; set; }
    }

    public class CreateBudgetItemRequest
    {
        [JsonProperty(PropertyName = "orcamentoId")]
        public int? OrcamentoId { get; set; }
        [JsonProperty(PropertyName = "cnpjCpf")]
        public long CnpjCpf { get; set; }
        [JsonProperty(PropertyName = "codigoCliente")]
        public int CodigoCliente { get; set; }
        [JsonProperty(PropertyName = "codigoCondPagamento")]
        public int CodigoCondPagamento { get; set; }
        [JsonProperty(PropertyName = "codigoRepresentante")]
        public int? CodigoRepresentante { get; set; }
        [JsonProperty(PropertyName = "codigoItem")]
        public string CodigoItem { get; set; }
        [JsonProperty(PropertyName = "mascaraId")]
        public int? MascaraId { get; set; }
        [JsonProperty(PropertyName = "quantidade")]
        public int Quantidade { get; set; }
    }
}
