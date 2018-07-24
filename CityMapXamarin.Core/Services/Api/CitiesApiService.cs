using CityMapXomarin.Core.Infastrucure;
using CityMapXomarin.Core.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityMapXomarin.Core.Services.Api
{
    public class CitiesApiService : ICitiesApiService
    {
        private const string WEB_API_URL = "https://api.myjson.com/bins/7ybe5";

        public async Task<Data> GetDataAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var responce = await httpClient.GetAsync(new Uri(WEB_API_URL));
                return await GetContentResponceAsync(responce);
            }
        }

        private async Task<Data> GetContentResponceAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException();
            }

            var contentResponce = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Data>(contentResponce);
        }
    }
}
