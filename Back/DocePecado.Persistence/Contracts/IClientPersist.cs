using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contracts
{
    public interface IClientPersist
    {
        //CLIENT
        Task<Client[]> GetAllClientsAsync();
        Task<Client[]> GetAllClientsByNameAsync(string name);
        Task<Client> GetClientByIdAsync(int clientId);
    }
}
