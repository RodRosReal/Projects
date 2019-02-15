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
    public class UpdateBudgetItemResponse
    {
        [JsonProperty(PropertyName = "Value")]
        public List<BudgetItem> Rows { get; set; }
    }

    public  class UpdateBudgetItemRequest
    {
        [JsonProperty(PropertyName = "itemId")]
        public int ItemId { get; set; }        
        [JsonProperty(PropertyName = "quantidade")]
        public int Quantidade { get; set; }
    }
}
