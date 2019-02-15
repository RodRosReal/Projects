using System.Runtime.Serialization;

namespace Domain.ValueObjects.Base
{
    [DataContract]
    public class DeliveryTime
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int TimeInDays { get; set; }
    }
}
