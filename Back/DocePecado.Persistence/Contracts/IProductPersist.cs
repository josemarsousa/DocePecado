using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contracts
{
    public interface IProductPersist
    {
        Task<Product[]> GetAllProductsAsync();
        Task<Product[]> GetAllProductsByNameAsync(string name);
        Task<Product> GetProductByIdAsync(long productId);
    }
}
