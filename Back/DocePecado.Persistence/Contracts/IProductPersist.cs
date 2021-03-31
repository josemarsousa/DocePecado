using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contracts
{
    public interface IProductPersist
    {
        Task<Product[]> GetAllProductsAsync(bool includeOrders = false);
        Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders = false);
        Task<Product> GetProductByIdAsync(int productId, bool includeOrders = false);
    }
}
