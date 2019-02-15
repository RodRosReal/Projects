using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class ListBudgetItem
    {
        public ListBudgetItem()
        {
            this.Items = new List<BudgetItem>();
        }

        public List<BudgetItem> Items { get; set; }
    }
}
