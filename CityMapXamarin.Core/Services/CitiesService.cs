using CityMapXomarin.Core.Infastrucure;
using CityMapXomarin.Core.Models;
using CityMapXomarin.Core.Services.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

 namespace CityMapXomarin.Core.Services
{
    public class CitiesService : ICitiesService
    {
        ICitiesApiService _citiesApiService;

        public CitiesService()
        {
            _citiesApiService = new CitiesApiService();
        }

        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            return (await _citiesApiService.GetDataAsync()).Cities;
        }
    }
}
