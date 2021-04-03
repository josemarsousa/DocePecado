using DocePecado.Application.Dtos;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    public interface IOrderService
    {
        Task<OrderDto> AddOrder(OrderDto model);
        Task<OrderDto> UpdateOrder(long orderId, OrderDto model);
        Task<bool> DeleteOrder(long orderId);

        Task<OrderDto[]> GetAllOrdersAsync(bool includeProducts = false);
        Task<OrderDto[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false);
        Task<OrderDto> GetOrderByIdAsync(long orderId, bool includeProducts = false);
    }
}
