using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.ValueObjects
{
    [DataContract]
    public class DeleteBudgetResponse
    {
        [JsonProperty(PropertyName = "Succeeded")]
        public bool Succeeded { get; set; }
    }

    public class DeleteBudgetRequest
    {
        [JsonProperty(PropertyName = "orcamentoId")]
        public int BudgetId { get; set; }        
    }
}
