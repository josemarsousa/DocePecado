using DocePecado.Application.Contracts;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace DocePecado.Application
{
    public class DistrictService : IDistrictService
    {
        private readonly IGeneralPersist generalPersist;
        private readonly IDistrictPersist districtPersist;

        public DistrictService(IGeneralPersist generalPersist, IDistrictPersist districtPersist)
        {
            this.generalPersist = generalPersist;
            this.districtPersist = districtPersist;
        }
        public async Task<District> AddClient(District model)
        {
            try
            {
                this.generalPersist.Add<District>(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.districtPersist.GetDistrictByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<District> UpdateClient(long districtId, District model)
        {
            try
            {
                var district = await this.districtPersist.GetDistrictByIdAsync(districtId);
                if (district == null) return null;

                model.Id = district.Id;

                this.generalPersist.Update(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.districtPersist.GetDistrictByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteClient(long districtId)
        {
            try
            {
                var district = await this.districtPersist.GetDistrictByIdAsync(districtId);
                if (district == null) throw new Exception("Bairro não encontrado");

                this.generalPersist.Delete<District>(district);
                return await this.generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<District[]> GetAllDistrictsAsync()
        {
            try
            {
                var district = await this.districtPersist.GetAllDistrictsAsync();
                if (district == null) return null;

                return district;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<District[]> GetAllDistrictsByNameAsync(string name)
        {
            try
            {
                var district = await this.districtPersist.GetAllDistrictsByNameAsync(name);
                if (district == null) return null;

                return district;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<District> GetDistrictByIdAsync(long districtId)
        {
            try
            {
                var district = await this.districtPersist.GetDistrictByIdAsync(districtId);
                if (district == null) return null;

                return district;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
