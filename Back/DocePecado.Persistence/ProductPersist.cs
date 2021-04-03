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

        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = this.context.Products;

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByNameAsync(string name)
        {
            IQueryable<Product> query = this.context.Products;

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductByIdAsync(long productId)
        {
            IQueryable<Product> query = this.context.Products;

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Id == productId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
