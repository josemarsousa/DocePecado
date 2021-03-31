using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Application.Contracts
{
    public interface IDistrictService
    {
        Task<District> AddDistrict(District model);
        Task<District> UpdateDistrict(long districtId, District model);
        Task<bool> DeleteDistrict(long districtId);

        Task<District[]> GetAllDistrictsAsync();
        Task<District[]> GetAllDistrictsByNameAsync(string name);
        Task<District> GetDistrictByIdAsync(long districtId);
    }
}
