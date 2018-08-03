using CityMapXamarin.Core.Models;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infrastructure
{
    public interface INavigationManager
    {
        Task NavigateToCityAsync(CityModel city);
        Task NavigateToCityMapAsync();
    }
}
