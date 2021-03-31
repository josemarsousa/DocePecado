using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    public interface IClientService
    {
        Task<Client> AddClient(Client model);
        Task<Client> UpdateClient(long clientId, Client model);
        Task<bool> DeleteClient(long clientId);

        Task<Client[]> GetAllClientsAsync();
        Task<Client[]> GetAllClientsByNameAsync(string name);
        Task<Client> GetClientByIdAsync(long clientId);
    }
}
