using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.ValueObjects
{
    [DataContract]
    public  class GetItemsResponse 
    {
       [JsonProperty(PropertyName = "TotalRowCount")]
        public int TotalRowCount { get; set; }
       [JsonProperty(PropertyName = "Rows")]
        public List<Product> Rows { get; set; }
    }

    [DataContract]
    public class Product
    {
       [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }
       [JsonProperty(PropertyName = "Codigo")]
        public string Codigo { get; set; }
       [JsonProperty(PropertyName = "Descricao")]
        public string Descricao { get; set; }
       [JsonProperty(PropertyName = "Fornecedor")]
        public string Fornecedor { get; set; }
    }

    public  class GetItemsRequest
    {
        [JsonProperty(PropertyName = "skip")]
        public int Skip { get; set; }
        [JsonProperty(PropertyName = "take")]
        public int Take { get; set; }
    }
}


