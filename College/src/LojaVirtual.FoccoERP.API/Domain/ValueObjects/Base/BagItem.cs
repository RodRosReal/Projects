using System.Runtime.Serialization;

namespace Domain.ValueObjects.Base
{
    [DataContract]
    public class BagItem
    {
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
    }
}
