using CityMapXamarin.Core.Models;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace CityMapXamarin.Core.ViewModels
{
    public class CityMapViewModel : MvxViewModel<ObservableCollection<CityModel>>
    {
        private ObservableCollection<CityModel> _cities;
        public ObservableCollection<CityModel> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public override void Prepare(ObservableCollection<CityModel> parameter)
        {
            _cities = parameter;
        }
    }
}
