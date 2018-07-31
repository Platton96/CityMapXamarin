using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private int _number;
        private readonly INavigationManager _navigationManager;

        private ObservableCollection<CityModel> _cities;

        private readonly ICitiesService _citiesService;
        public ICommand IncrementCommand => new MvxCommand(DoIncrement);

        public ICommand DecrementCommand => new MvxCommand(DoDecrement);
        public ICommand NavigateToCityCommand => new MvxAsyncCommand<CityModel>(DoNavigateToCityAsync);

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                RaisePropertyChanged(() => Number);
            }
        }

        public ObservableCollection<CityModel> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public MainPageViewModel(ICitiesService citiesService, INavigationManager navigationManager)
        {
            _citiesService = citiesService;
            _navigationManager = navigationManager;
        }

        public override async void ViewCreated()
        {
            base.ViewCreated();
            Cities = new ObservableCollection<CityModel>(await _citiesService.GetCitiesAsync());

        }

        private async Task DoNavigateToCityAsync(CityModel city)
        {
            await _navigationManager.NavigateToCityAsync(city);
        }

        private void DoIncrement()
        {
            Number++;
        }

        private void DoDecrement()
        {
            Number--;
        }
    }
}