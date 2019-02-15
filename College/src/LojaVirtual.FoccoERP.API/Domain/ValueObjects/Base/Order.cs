using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.ValueObjects.Base
{
    [DataContract]
    public class Order
    {
        [JsonProperty(PropertyName = "IdPedido")]
        public int OrderId { get; set; }
        public string Uf { get; set; }
        [JsonProperty(PropertyName = "ValorLiquido")]
        public decimal ValorLiquido { get; set; }
        [JsonProperty(PropertyName = "ValorIpi")]
        public decimal ValorIpi { get; set; }
        [JsonProperty(PropertyName = "ValorSubIcms")]
        public decimal ValorSubIcms { get; set; }

        [JsonProperty(PropertyName = "Itens")]
        public List<OrderItem> Items { get; set; }
    }

    [DataContract]
    public class OrderItem
    {
        public string Uf { get; set; }
        [JsonProperty(PropertyName = "IdItem")]
        public int IdItem { get; set; }
        [JsonProperty(PropertyName = "ValorLiquido")]
        public decimal ValorLiquido { get; set; }
        [JsonProperty(PropertyName = "ValorIpi")]
        public decimal ValorIpi { get; set; }
        [JsonProperty(PropertyName = "ValorSubIcms")]
        public decimal ValorSubIcms { get; set; }
    }
}
