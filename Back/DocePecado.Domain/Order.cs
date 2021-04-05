using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocePecado.Domain
{
    public class Order : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? DateOrder { get; set; }
        public DateTime? DateDelivery { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }

    }
}
