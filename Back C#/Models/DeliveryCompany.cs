namespace Models
{
    public class DeliveryCompany
    {
        public int DeliveryCompanyId { get; set; }
        public required string CompanyName { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public ICollection<DeliveryPerson>? DeliveryPersons { get; set; }
    }
}
