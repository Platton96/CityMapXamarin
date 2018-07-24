using CityMapXomarin.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXomarin.Core.Infastrucure
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityModel>> GetCitiesAsync();
    }
}
