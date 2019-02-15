using Domain.ValueObjects.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class ListStocks
    {
        public ListStocks()
        {
            this.Items = new List<StockItem>();
        }

        public List<StockItem> Items { get; set; }
    }
}
