using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.ValueObjects
{
    [DataContract]
    public class DeleteBudgetItemResponse
    {
        [JsonProperty(PropertyName = "Succeeded")]
        public bool Succeeded { get; set; }
    }

    public class DeleteBudgetItemRequest
    {
        [JsonProperty(PropertyName = "itemId")]
        public int ItemId { get; set; }        
    }
}
