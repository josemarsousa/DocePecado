using DocePecado.Application.Contracts;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocePecado.Application
{
    class OrderService : IOrderService
    {
        private readonly IGeneralPersist generalPersist;
        private readonly IOrderPersist orderPersist;

        public OrderService(IGeneralPersist generalPersist, IOrderPersist orderPersist)
        {
            this.generalPersist = generalPersist;
            this.orderPersist = orderPersist;
        }
        public async Task<Order> AddOrder(Order model)
        {
            try
            {
                this.generalPersist.Add<Order>(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.orderPersist.GetOrderByIdAsync(model.Id, false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteClient(long clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Order[]> GetAllOrdersAsync(bool includeProducts = false)
        {
            throw new NotImplementedException();
        }

        public Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int orderId, bool includeProducts = false)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateClient(long clientId, Order model)
        {
            throw new NotImplementedException();
        }
    }
}
