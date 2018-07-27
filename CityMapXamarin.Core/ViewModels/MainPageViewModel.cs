using System.Collections.ObjectModel;
using System.Windows.Input;
using CityMapXamarin.Core.Infastrucure;
using CityMapXamarin.Core.Models;
using MvvmCross.Core.ViewModels;

namespace CityMapXamarin.Core.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private int _number;

        private ObservableCollection<CityModel> _cities;

        private readonly ICitiesService _citiesService;
        public ICommand IncrementCommand => new MvxCommand(DoIncrement);
        public ICommand IncremhghjgentCommand => new MvxCommand<CityModel>(DoIncbnbvrement);

        private void DoIncbnbvrement(CityModel obj)
        {
            ShowViewModel<CityViewModel>(obj);
        }

        public ICommand DecrementCommand => new MvxCommand(DoDecrement);

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

        public MainPageViewModel(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }
        public override async void ViewCreated()
        {
            base.ViewCreated();
            Cities = new ObservableCollection<CityModel>(await _citiesService.GetCitiesAsync());

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
