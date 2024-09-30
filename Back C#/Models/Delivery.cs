namespace Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string? TrackingNumber { get; set; }
        public required DateTime DeliveryDate { get; set; }
        public required int OrderId { get; set; }
        public required Order Order { get; set; }
        public required int DeliveryPersonId { get; set; }
        public required DeliveryPerson DeliveryPerson { get; set; }
        public required int DeliveryAddressId { get; set; }
        public required Address DeliveryAddress { get; set; }
    }
}
