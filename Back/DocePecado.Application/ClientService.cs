using DocePecado.Application.Contracts;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocePecado.Application
{
    class ClientService : IClientService
    {
        private readonly IGeneralPersist generalPersist;
        private readonly IClientPersist clientPersist;

        public ClientService(IGeneralPersist generalPersist, IClientPersist clientPersist)
        {
            this.generalPersist = generalPersist;
            this.clientPersist = clientPersist;
        }
        public async Task<Client> AddClient(Client model)
        {
            try
            {
                this.generalPersist.Add<Client>(model);
                if(await this.generalPersist.SaveChangesAsync())
                {
                    return await this.clientPersist.GetClientByIdAsync(model.Id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteClient(long clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Client[]> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client[]> GetAllClientsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByIdAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateClient(long clientId, Client model)
        {
            throw new NotImplementedException();
        }
    }
}
