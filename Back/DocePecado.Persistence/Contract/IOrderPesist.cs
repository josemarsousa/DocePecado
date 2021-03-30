using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contract
{
    public interface IOrderPersist
    {
        Task<Order[]> GetAllOrdersAsync(bool includeProducts);
        Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts);
        Task<Order> GetOrderByIdAsync(int orderId, bool includeProducts);
    }
}
