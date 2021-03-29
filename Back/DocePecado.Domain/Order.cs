using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocePecado.Domain
{
    public class Order : BaseModel
    {
        public long Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? DateOrder { get; set; }
        public DateTime? DateDelivery { get; set; }
        [StringLength(500)]
        public string Note { get; set; }
        public decimal Price { get; set; }
        [StringLength(1)]
        public string Status { get; set; }
        public Client Client { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }

    }
}
