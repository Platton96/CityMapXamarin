using CityMapXamarin.Core.DataModels;
using CityMapXamarin.Core.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Services.Api
{
    public class CitiesApiService : ICitiesApiService
    {
        private const string WEB_API_URL = "https://api.myjson.com/bins/7ybe5";

        public async Task<CitiesData> GetDataAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var responce = await httpClient.GetAsync(new Uri(WEB_API_URL));
                return await GetContentResponceAsync(responce);
            }
        }

        private async Task<CitiesData> GetContentResponceAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            try
            {
                var contentResponce = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CitiesData>(contentResponce);
            }
            catch
            {
                return null;
            }
        }

        public async Task<byte[]> GetCityImgeAsync(string imageUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var responce = await httpClient.GetAsync(new Uri(imageUrl));
                if (responce.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                return await responce.Content.ReadAsByteArrayAsync();
            }
        }
    }
}
