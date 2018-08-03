using CityMapXamarin.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infrastructure
{
    public interface ICitiesService
    {
        IEnumerable<CityModel> Cities { get; }
        Task<IEnumerable<CityModel>> GetCitiesAsync();
    }
}
