using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product model);
        Task<Product> UpdateProduct(long productId, Product model);
        Task<bool> DeleteProduct(long productId);

        Task<Product[]> GetAllProductsAsync(bool includeOrders = false);
        Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders = false);
        Task<Product> GetProductByIdAsync(long productId, bool includeOrders = false);
    }
}
