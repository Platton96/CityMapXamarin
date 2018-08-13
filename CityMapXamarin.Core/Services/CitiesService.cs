using CityMapXamarin.Core.DataModels;
using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Models;
using MvvmCross.Plugin.File;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesApiService _citiesApiService;
        private readonly IMvxFileStoreAsync _mvxFileStore;


        public CitiesService(ICitiesApiService citiesApiService, IMvxFileStoreAsync mvxFileStore)
        {
            _citiesApiService = citiesApiService;
            _mvxFileStore = mvxFileStore;
        }

        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            var citiesJason = SettingsManager.AccessCitities;

            if (!string.IsNullOrEmpty(citiesJason))
            {
                return JsonConvert.DeserializeObject<IEnumerable<CityModel>>(citiesJason);
            }

            var citiesData = await _citiesApiService.GetDataAsync();
            var cities = new List<CityModel>();

            foreach (var cityData in citiesData.Cities)
            {
                var cityModel = await GetCityAsync(cityData);
                cities.Add(cityModel);
            }

            SettingsManager.AccessCitities = JsonConvert.SerializeObject(cities);

            return cities;
        }

        private async Task<CityModel> GetCityAsync(CityData cityData)
        {
            string filePath;

            try
            {
                var cityImage = await _citiesApiService.GetCityImgeAsync(cityData.ImageUrl);
                await _mvxFileStore.WriteFileAsync(cityData.Name, cityImage);
                filePath = cityData.Name;

            }
            catch
            {
                filePath = null;
            }

             return new CityModel(cityData, filePath);
        }
    } 
}
