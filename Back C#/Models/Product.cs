namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Label { get; set; }
        public required string Reference { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public int? TypeProductId { get; set; }
        public TypeProduct? TypeProduct { get; set; }
        public required ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
