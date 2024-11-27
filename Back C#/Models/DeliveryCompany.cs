using System.Text.Json.Serialization;

namespace Models
{
    public class DeliveryCompany
    {
        public int DeliveryCompanyId { get; set; }
        public required string CompanyName { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        [JsonIgnore]
        public ICollection<DeliveryPerson>? DeliveryPersons { get; set; }
    }
}
