using CityMapXamarin.Core.DataModels;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infrastructure
{
    public interface ICitiesApiService
    {
        Task<CitiesData> GetDataAsync();
        Task<byte[]> GetCityImgeAsync(string imageUrl);
    }
}
