using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocePecado.Domain
{
    public class District : BaseModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceDelivery { get; set; }
    }
}
