using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contracts
{
    public interface IOrderPersist
    {
        Task<Order[]> GetAllOrdersAsync(bool includeProducts = false);
        Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false);
        Task<Order> GetOrderByIdAsync(long orderId, bool includeProducts = false);
    }
}
