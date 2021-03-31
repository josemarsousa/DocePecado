using DocePecado.Application.Contracts;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
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
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> UpdateClient(long orderId, Order model)
        {
            try
            {
                var order = await this.orderPersist.GetOrderByIdAsync(orderId, false);
                if (order == null) return null;

                model.Id = order.Id;

                this.generalPersist.Update(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.orderPersist.GetOrderByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteClient(long orderId)
        {
            try
            {
                var order = await this.orderPersist.GetOrderByIdAsync(orderId, false);
                if (order == null) throw new Exception("Pedido não encontrado");

                this.generalPersist.Delete<Order>(order);
                return await this.generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order[]> GetAllOrdersAsync(bool includeProducts = false)
        {
            try
            {
                var orders = await this.orderPersist.GetAllOrdersAsync(includeProducts);
                if (orders == null) return null;

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false)
        {
            try
            {
                var orders = await this.orderPersist.GetAllOrdersByNameAsync(name, includeProducts);
                if (orders == null) return null;

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> GetOrderByIdAsync(long orderId, bool includeProducts = false)
        {
            try
            {
                var orders = await this.orderPersist.GetOrderByIdAsync(orderId, includeProducts);
                if (orders == null) return null;

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
