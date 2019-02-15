using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class SyncItems
    {        
        [JsonProperty(PropertyName = "TotalRowCount")]
        public int TotalRowCount { get; set; }

        [JsonProperty(PropertyName = "TotalProcessedRows")]
        public int TotalProcessedRows { get; set; }

        [JsonProperty(PropertyName = "EndOfRecords")]
        public bool EndOfRecords { get; set; }

        
    }
}
