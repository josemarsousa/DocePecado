using AutoMapper;
using DocePecado.Application.Dtos;
using DocePecado.Domain;

namespace DocePecado.Apl.Helpers
{
    public class DocePecadoProfile : Profile
    {
        public DocePecadoProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            //CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
        }
    }
}
