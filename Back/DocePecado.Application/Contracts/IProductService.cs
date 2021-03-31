using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    interface IProductService
    {
        Task<Product> AddOrder(Product model);
        Task<Product> UpdateClient(long productId, Product model);
        Task<bool> DeleteClient(long productId);

        Task<Product[]> GetAllProductsAsync(bool includeOrders = false);
        Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders = false);
        Task<Product> GetProductByIdAsync(long productId, bool includeOrders = false);
    }
}
