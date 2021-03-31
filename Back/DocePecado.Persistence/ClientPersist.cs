using DocePecado.Domain;
using DocePecado.Persistence.Contexts;
using DocePecado.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public class ClientPersist : IClientPersist
    {
        private readonly AppDbContext context;
        public ClientPersist(AppDbContext context)
        {
            this.context = context;
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

        public async Task<Client> GetClientByIdAsync(long clientId)
        {
            IQueryable<Client> query = this.context.Clients
                .Include(c => c.Orders);

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Id == clientId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
