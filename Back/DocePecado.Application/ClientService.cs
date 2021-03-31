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
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Client> UpdateClient(long clientId, Client model)
        {
            try
            {
                var client = await this.clientPersist.GetClientByIdAsync(clientId);
                if (client == null) return null;

                model.Id = client.Id;

                this.generalPersist.Update(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.clientPersist.GetClientByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteClient(long clientId)
        {
            try
            {
                var client = await this.clientPersist.GetClientByIdAsync(clientId);
                if (client == null) throw new Exception("Cliente não encontrado");

                this.generalPersist.Delete<Client>(client);
                return await this.generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Client[]> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client[]> GetAllClientsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByIdAsync(long clientId)
        {
            throw new NotImplementedException();
        }
    }
}
