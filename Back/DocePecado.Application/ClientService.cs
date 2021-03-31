using DocePecado.Application.Contracts;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace DocePecado.Application
{
    public class ClientService : IClientService
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

        public async Task<Client[]> GetAllClientsAsync()
        {
            try
            {
                var client = await this.clientPersist.GetAllClientsAsync();
                if (client == null) return null;

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Client[]> GetAllClientsByNameAsync(string name)
        {
            try
            {
                var client = await this.clientPersist.GetAllClientsByNameAsync(name);
                if (client == null) return null;

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Client> GetClientByIdAsync(long clientId)
        {
            try
            {
                var client = await this.clientPersist.GetClientByIdAsync(clientId);
                if (client == null) return null;

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
