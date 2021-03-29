using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocePecado.Domain
{
    public class Product
    {
        public long Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}
