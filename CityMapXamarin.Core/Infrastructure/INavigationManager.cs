using CityMapXamarin.Core.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Infrastructure
{
    public interface INavigationManager
    {
        Task NavigateToCityAsync(CityModel city);
        Task NavigateToCityMapAsync(ObservableCollection<CityModel> cities);

        Task NavigateMainPageAsync();
    }
}
