using DocePecado.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public class DocePecadoPersistence : IDocePecadoPersistence
    {
        private readonly AppDbContext context;
        public DocePecadoPersistence(AppDbContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            this.context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }

        public async Task<Client[]> GetAllClientsAsync()
        {
            IQueryable<Client> query = this.context.Clients
                .Include(c => c.Orders);

            query = query.OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Client[]> GetAllClientsByNameAsync(string name)
        {
            IQueryable<Client> query = this.context.Clients
                .Include(c => c.Orders);

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            IQueryable<Client> query = this.context.Clients
                .Include(c => c.Orders);

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Id == clientId);

            return await query.FirstOrDefaultAsync();
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

        public async Task<Order> GetOrderByIdAsync(int orderId, bool includeProducts = false)
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

        public async Task<District[]> GetAllDistrictsAsync()
        {
            IQueryable<District> query = this.context.Districts;

            query = query.OrderBy(d => d.Id);

            return await query.ToArrayAsync();
        }

        public async Task<District[]> GetAllDistrictsByNameAsync(string name)
        {
            IQueryable<District> query = this.context.Districts;

            query = query.OrderBy(d => d.Id)
                .Where(d => d.Name.ToLower().Contains(name.ToLower());

            return await query.ToArrayAsync();
        }

        public async Task<District> GetDistrictByIdAsync(int districtId)
        {
            IQueryable<District> query = this.context.Districts;

            query = query.OrderBy(d => d.Id)
                .Where(d => d.Id == districtId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
