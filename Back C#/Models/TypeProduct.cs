namespace Models
{
    public class TypeProduct
    {
        public int TypeProductId { get; set; }
        public required string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
