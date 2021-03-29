using DocePecado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocePecado.Persistence
{
    public interface IDocePecadoPersistence
    {
        //GENERAL
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        //CLIENT
        Task<Client[]> GetAllClientsAsync();
        Task<Client[]> GetAllClientsByNameAsync(string name);
        Task<Client> GetClientByIdAsync(int clientId);

        //ORDER
        Task<Order[]> GetAllOrdersAsync(bool includeProducts);
        Task<Order[]> GetAllOrdersByNameAsync(string name, bool includeProducts);
        Task<Order> GetOrderByIdAsync(int orderId, bool includeProducts);

        //PRODUCT
        Task<Product[]> GetAllProductsAsync(bool includeOrders);
        Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders);
        Task<Product> GetProductByIdAsync(int productId, bool includeOrders);

        //DISTRICT
        Task<District[]> GetAllDistrictsAsync();
        Task<District[]> GetAllDistrictsByNameAsync(string name);
        Task<District> GetDistrictByIdAsync(int districtId);


    }
}
