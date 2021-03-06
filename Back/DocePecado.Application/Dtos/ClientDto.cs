using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocePecado.Application.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DistrictId { get; set; }
        public DistrictDto District { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
