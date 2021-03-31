using DocePecado.Domain;
using DocePecado.Persistence.Contexts;
using DocePecado.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public class ProductPersist : IProductPersist
    {
        private readonly AppDbContext context;
        public ProductPersist(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Product[]> GetAllProductsAsync(bool includeOrders = false)
        {
            IQueryable<Product> query = this.context.Products;

            if (includeOrders)
            {
                query = query
                    .Include(p => p.OrderProducts)
                    .ThenInclude(op => op.Order);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders = false)
        {
            IQueryable<Product> query = this.context.Products;

            if (includeOrders)
            {
                query = query
                    .Include(p => p.OrderProducts)
                    .ThenInclude(op => op.Order);
            }

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId, bool includeOrders = false)
        {
            IQueryable<Product> query = this.context.Products;

            if (includeOrders)
            {
                query = query
                    .Include(p => p.OrderProducts)
                    .ThenInclude(op => op.Order);
            }

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Id == productId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
