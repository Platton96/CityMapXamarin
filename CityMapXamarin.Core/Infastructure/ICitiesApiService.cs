using CityMapXomarin.Core.Models;
using System.Threading.Tasks;

namespace CityMapXomarin.Core.Infastrucure
{
    public interface ICitiesApiService
    {
        Task<Data> GetDataAsync();
    }
}
