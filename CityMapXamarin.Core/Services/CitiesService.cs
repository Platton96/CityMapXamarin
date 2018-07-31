using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesApiService _citiesApiService;

        public CitiesService(ICitiesApiService citiesApiService)
        {
            _citiesApiService = citiesApiService;
        }

        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            return (await _citiesApiService.GetDataAsync()).Cities;
        }
    }
}
