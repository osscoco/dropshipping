using System.Text.Json.Serialization;

namespace Models.Identity
{
    public class Client : User
    {
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
        [JsonIgnore]
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
