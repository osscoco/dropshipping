using Models.Identity;
using System.Text.Json.Serialization;

namespace Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required DateTime OrderDate { get; set; }
        public required string Status { get; set; }
        public required int ClientId { get; set; }
        public required Client Client { get; set; }
        public required int DeliveryAddressId { get; set; }
        public required Address DeliveryAddress { get; set; }
        public required int DeliveryId { get; set; }
        public required Delivery Delivery { get; set; }
        [JsonIgnore]
        public required ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
