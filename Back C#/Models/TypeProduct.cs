using System.Text.Json.Serialization;

namespace Models
{
    public class TypeProduct
    {
        public int TypeProductId { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
