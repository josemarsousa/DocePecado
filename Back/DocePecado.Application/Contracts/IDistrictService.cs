using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    interface IDistrictService
    {
        Task<District> AddClient(District model);
        Task<District> UpdateClient(long districtId, District model);
        Task<bool> DeleteClient(long districtId);

        Task<District[]> GetAllDistrictsAsync();
        Task<District[]> GetAllDistrictsByNameAsync(string name);
        Task<District> GetDistrictByIdAsync(long districtId);
    }
}
