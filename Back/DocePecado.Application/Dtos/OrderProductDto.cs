namespace DocePecado.Application.Dtos
{
    public class OrderProductDto
    {
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}
