using AutoMapper;
using DocePecado.Application.Contracts;
using DocePecado.Application.Dtos;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace DocePecado.Application
{
    public class OrderService : IOrderService
    {
        private readonly IGeneralPersist generalPersist;
        private readonly IOrderPersist orderPersist;
        private readonly IMapper mapper;

        public OrderService(IGeneralPersist generalPersist, IOrderPersist orderPersist, IMapper mapper)
        {
            this.generalPersist = generalPersist;
            this.orderPersist = orderPersist;
            this.mapper = mapper;
        }
        public async Task<OrderDto> AddOrder(OrderDto model)
        {
            try
            {
                var order = this.mapper.Map<Order>(model);

                this.generalPersist.Add<Order>(order);

                if (await this.generalPersist.SaveChangesAsync())
                {
                    var orderReturn = await this.orderPersist.GetOrderByIdAsync(order.Id, false);
                    return this.mapper.Map<OrderDto>(orderReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDto> UpdateOrder(long orderId, OrderDto model)
        {
            try
            {
                var order = await this.orderPersist.GetOrderByIdAsync(orderId, false);
                if (order == null) return null;

                model.Id = order.Id;

                this.mapper.Map(model, order);

                this.generalPersist.Update<Order>(order);

                if (await this.generalPersist.SaveChangesAsync())
                {
                    var orderReturn = await this.orderPersist.GetOrderByIdAsync(order.Id, false);
                    return this.mapper.Map<OrderDto>(orderReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteOrder(long orderId)
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

        public async Task<OrderDto[]> GetAllOrdersAsync(bool includeProducts = false)
        {
            try
            {
                var orders = await this.orderPersist.GetAllOrdersAsync(includeProducts);
                if (orders == null) return null;

                var result = this.mapper.Map<OrderDto[]>(orders);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDto[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false)
        {
            try
            {
                var orders = await this.orderPersist.GetAllOrdersByNameAsync(name, includeProducts);
                if (orders == null) return null;

                var result = this.mapper.Map<OrderDto[]>(orders);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDto> GetOrderByIdAsync(long orderId, bool includeProducts = false)
        {
            try
            {
                var order = await this.orderPersist.GetOrderByIdAsync(orderId, includeProducts);
                if (order == null) return null;

                var result = this.mapper.Map<OrderDto>(order);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
