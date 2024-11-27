using Models.Identity;
using System.Text.Json.Serialization;

namespace Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string? StreetNumber { get; set; }
        public required string StreetName { get; set; }
        public string? AdditionalInfo { get; set; }
        public required int CityId { get; set; }
        public required City City { get; set; }
        [JsonIgnore]
        public ICollection<Client>? Clients { get; set; }
    }
}
