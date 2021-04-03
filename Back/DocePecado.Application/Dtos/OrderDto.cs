using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocePecado.Application.Dtos
{
    public class OrderDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DateOrder { get; set; }
        public string DateDelivery { get; set; }
        public string Note { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get; set; }
        public string Status { get; set; }
        public ClientDto Client { get; set; }
        public IEnumerable<OrderProductDto> OrderProducts { get; set; }
    }
}
