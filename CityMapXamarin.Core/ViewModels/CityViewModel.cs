using CityMapXamarin.Core.Models;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core.ViewModels
{
    public class CityViewModel : MvxViewModel<CityModel>
    {
        private CityModel _city;
        public CityModel City
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged(() => City);
            }
        }

        public override void Prepare(CityModel parameter)
        {
            _city = parameter;
        }
    }
}
