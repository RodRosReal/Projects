using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class UpdateBudgetPaymentConditionResponse
    {
        public UpdateBudgetPaymentConditionResponse()
        {
            this.BudgetPaymentCondition = new Budget();
        }

        [JsonProperty(PropertyName = "Value")]
        public Budget BudgetPaymentCondition { get; set; }
    }

    public  class UpdateBudgetPaymentConditionRequest
    {
        [JsonProperty(PropertyName = "codigoCondPagamento")]
        public int PaymentConditionCode { get; set; }
        [JsonProperty(PropertyName = "orcamentoId")]
        public int BudgetId { get; set; }
    }
}
