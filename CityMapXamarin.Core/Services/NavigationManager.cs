using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.Services
{
    public class NavigationManager : INavigationManager
    {
        private readonly IMvxNavigationService _navigationService;
        public NavigationManager(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task NavigateMainPageAsync()
        {
            await _navigationService.Navigate<MainPageViewModel>();
        }

        public async Task NavigateToCityAsync(CityModel city)
        {
            await _navigationService.Navigate<CityViewModel, CityModel>(city);
        }

        public async Task NavigateToCityMapAsync(ObservableCollection<CityModel>  cities)
        {
            await _navigationService.Navigate<CityMapViewModel, ObservableCollection<CityModel>>(cities);
        }

    }
}
