using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.ValueObjects
{
    [DataContract]
    public class GetStockItemResponse
    {
        [JsonProperty(PropertyName = "Value")]
        public List<StockItem> Rows { get; set; }
    }

    [DataContract]
    public class StockItem
    {
        [JsonProperty(PropertyName = "CodigoEmpresa")]
        public int CodigoEmpresa { get; set; }
        [JsonProperty(PropertyName = "Uf")]
        public string Uf { get; set; }
        [JsonProperty(PropertyName = "Saldo")]
        public decimal Saldo { get; set; }
    }

    public  class GetStockItemRequest
    {
        [JsonProperty(PropertyName = "codigoItem")]
        public string ItemCode { get; set; }
        [JsonProperty(PropertyName = "mascaraId")]
        public int? MascaraId { get; set; }
    }
}
