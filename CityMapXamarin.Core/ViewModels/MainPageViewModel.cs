using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private readonly ICitiesService _citiesService;
        private readonly IMvxNavigationService _navigationService;

        private ObservableCollection<CityModel> _cities;

        public IMvxCommand NavigateToCityCommand => new MvxAsyncCommand<CityModel>(DoNavigateToCityAsync);
        public IMvxCommand NavigateToCityMapCommand => new MvxAsyncCommand(DoNavigateToCityMapAsync);
        public IMvxCommand NavigateToMicrochartCommand => new MvxAsyncCommand(DoNavigateToMicrochartAsync);
        public IMvxCommand NavigateToRadialCommand => new MvxAsyncCommand(DoNavigateToRadialChartAsync);


        public ObservableCollection<CityModel> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public MainPageViewModel(ICitiesService citiesService, IMvxNavigationService navigationService)
        {
            _citiesService = citiesService;
            _navigationService = navigationService;
        }

        public override async void ViewCreated()
        {
            base.ViewCreated();
            Cities = new ObservableCollection<CityModel>(await _citiesService.GetCitiesAsync());
        }

        private async Task DoNavigateToCityAsync(CityModel city)
        {
            await _navigationService.Navigate<CityViewModel, CityModel>(city);
        }

        private async Task DoNavigateToCityMapAsync()
        {
            await _navigationService.Navigate<CityMapViewModel, ObservableCollection<CityModel>>(_cities);
        }
        private async Task DoNavigateToMicrochartAsync()
        {
            await _navigationService.Navigate<MicrochartViewModel>();
        }
        private async Task DoNavigateToRadialChartAsync()
        {
            await _navigationService.Navigate<RadialGaugeChartViewModel>();
        }
    }
}