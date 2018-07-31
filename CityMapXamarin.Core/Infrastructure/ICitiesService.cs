using CityMapXamarin.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infrastructure
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityModel>> GetCitiesAsync();
    }
}
