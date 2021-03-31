using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order model);
        Task<Order> UpdateOrder(long orderId, Order model);
        Task<bool> DeleteOrder(long orderId);

        Task<Order[]> GetAllOrdersAsync(bool includeProducts = false);
        Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false);
        Task<Order> GetOrderByIdAsync(long orderId, bool includeProducts = false);
    }
}
