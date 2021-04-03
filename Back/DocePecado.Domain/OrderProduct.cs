
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocePecado.Domain
{
    public class OrderProduct : BaseModel
    {
        public long Id { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
    }
}
