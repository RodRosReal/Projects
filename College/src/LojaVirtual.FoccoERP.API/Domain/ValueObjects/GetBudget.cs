using Domain.ValueObjects.Base;
using Newtonsoft.Json;

namespace Domain.ValueObjects
{
    public class GetBudgetResponse
    {
        public GetBudgetResponse()
        {
            this.Budget = new Budget();
        }

        [JsonProperty(PropertyName = "Value")]
        public Budget Budget { get; set; }
    }

    public class GetBudgetRequest
    {
        [JsonProperty(PropertyName = "orcamentoId")]
        public int BudgetId { get; set; }
    }
}
