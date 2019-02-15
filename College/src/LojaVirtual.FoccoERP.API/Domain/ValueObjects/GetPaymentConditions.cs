using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.ValueObjects
{
    [DataContract]
    public class GetPaymentConditionsResponse
    {
        [JsonProperty(PropertyName = "Rows")]
        public List<PaymentCondition> Rows { get; set; }
    }

    [DataContract]
    public class PaymentCondition
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Codigo")]
        public int Codigo { get; set; }
        [JsonProperty(PropertyName = "Descricao")]
        public string Descricao { get; set; }
}
}
