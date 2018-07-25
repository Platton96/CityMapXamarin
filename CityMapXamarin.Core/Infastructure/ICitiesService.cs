using CityMapXamarin.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infastrucure
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityModel>> GetCitiesAsync();
    }
}
