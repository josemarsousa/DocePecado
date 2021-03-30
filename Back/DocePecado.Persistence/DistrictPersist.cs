using DocePecado.Domain;
using DocePecado.Persistence.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public class DistrictPersist : IDistrictPersist
    {
        private readonly AppDbContext context;
        public DistrictPersist(AppDbContext context)
        {
            this.context = context;
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
                .Where(d => d.Name.ToLower().Contains(name.ToLower()));

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
