using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocePecado.Domain
{
    public class Client : BaseModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public District District { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
