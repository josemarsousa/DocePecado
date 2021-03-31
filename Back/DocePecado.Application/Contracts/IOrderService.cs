using DocePecado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    interface IOrderService
    {
        Task<Order> AddOrder(Order model);
        Task<Order> UpdateClient(long orderId, Order model);
        Task<bool> DeleteClient(long orderId);

        Task<Order[]> GetAllOrdersAsync(bool includeProducts = false);
        Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false);
        Task<Order> GetOrderByIdAsync(long orderId, bool includeProducts = false);
    }
}
