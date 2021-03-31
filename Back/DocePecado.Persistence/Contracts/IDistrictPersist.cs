using DocePecado.Domain;
using System.Threading.Tasks;

namespace DocePecado.Persistence.Contracts
{
    public interface IDistrictPersist
    {
        Task<District[]> GetAllDistrictsAsync();
        Task<District[]> GetAllDistrictsByNameAsync(string name);
        Task<District> GetDistrictByIdAsync(int districtId);


    }
}
