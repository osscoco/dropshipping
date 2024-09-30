namespace Models
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public required int OrderId { get; set; }
        public required Order Order { get; set; }
        public required int ProductId { get; set; }
        public required Product Product { get; set; }
    }
}
