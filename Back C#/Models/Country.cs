using Models.Identity;

namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public required string Name { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
