
namespace DocePecado.Domain
{
    public class OrderProduct : BaseModel
    {
        public long Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}
