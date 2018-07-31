using CityMapXamarin.Core.Models;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infrastructure
{
    public interface ICitiesApiService
    {
        Task<Data> GetDataAsync();
    }
}
