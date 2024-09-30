namespace Models.Identity
{
    public class Support : User
    {
        public ICollection<Ticket>? SupportedTickets { get; set; }
    }
}
