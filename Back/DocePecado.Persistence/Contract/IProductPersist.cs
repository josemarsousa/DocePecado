using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contract
{
    public interface IProductPersist
    {
        Task<Product[]> GetAllProductsAsync(bool includeOrders);
        Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders);
        Task<Product> GetProductByIdAsync(int productId, bool includeOrders);
    }
}
