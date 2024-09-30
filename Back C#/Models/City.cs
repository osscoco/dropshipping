using Models.Identity;

namespace Models
{
    public class City
    {
        public int CityId { get; set; }
        public required string Name { get; set; }
        public required string PostalCode { get; set; }
        public required int CountryId { get; set; }
        public required Country Country { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }
}
