using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.ValueObjects
{
    [DataContract]
    public class CreateOrderResponse
    {
        public CreateOrderResponse()
        {
            this.Order = new Order();
        }

        [JsonProperty(PropertyName = "Value")]
        public Order Order { get; set; }
    }

    public class CreateOrderRequest
    {
        [JsonProperty(PropertyName = "orcamentoId")]
        public int BudgetId { get; set; }
    }
}
