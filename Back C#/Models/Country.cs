using Models.Identity;
using System.Text.Json.Serialization;

namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<City>? Cities { get; set; }
    }
}
