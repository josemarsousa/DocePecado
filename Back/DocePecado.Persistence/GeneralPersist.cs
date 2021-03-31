using DocePecado.Persistence.Contexts;
using DocePecado.Persistence.Contracts;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public class GeneralPersist : IGeneralPersist
    {
        private readonly AppDbContext context;
        public GeneralPersist(AppDbContext context)
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
    }
}
