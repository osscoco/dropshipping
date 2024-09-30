using Models.Identity;

namespace Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public required int ClientId { get; set; }
        public required Client Client { get; set; }
        public int? SupportId { get; set; }
        public Support? Support { get; set; }
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
