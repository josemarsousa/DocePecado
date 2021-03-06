using DocePecado.Domain;
using DocePecado.Persistence.Contexts;
using DocePecado.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public class OrderPersist : IOrderPersist
    {
        private readonly AppDbContext context;
        public OrderPersist(AppDbContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Order[]> GetAllOrdersAsync(bool includeProducts = false)
        {
            IQueryable<Order> query = this.context.Orders
                .Include(o => o.Client);

            if (includeProducts)
            {
                query = query
                    .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product);
            }

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts = false)
        {
            IQueryable<Order> query = this.context.Orders
                .Include(o => o.Client);

            if (includeProducts)
            {
                query = query
                    .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product);
            }

            query = query.OrderBy(o => o.Id)
                .Where(o => o.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Order> GetOrderByIdAsync(long orderId, bool includeProducts = false)
        {
            IQueryable<Order> query = this.context.Orders
                .Include(o => o.Client);

            if (includeProducts)
            {
                query = query
                    .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product);
            }

            query = query.OrderBy(o => o.Id)
                .Where(o => o.Id == orderId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
