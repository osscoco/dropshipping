namespace Models.Identity
{
    public class Client : User
    {
        public int? AddressId { get; set; }
        public Address? Address { get; set; } 
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
