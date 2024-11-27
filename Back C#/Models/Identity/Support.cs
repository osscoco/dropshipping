using System.Text.Json.Serialization;

namespace Models.Identity
{
    public class Support : User
    {
        [JsonIgnore]
        public ICollection<Ticket>? SupportedTickets { get; set; }
    }
}
