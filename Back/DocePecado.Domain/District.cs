using System.ComponentModel.DataAnnotations;

namespace DocePecado.Domain
{
    public class District : BaseModel
    {
        public long Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public decimal PriceDelivery { get; set; }
    }
}
