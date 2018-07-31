using CityMapXamarin.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.ViewModels
{
    public class CityViewModel : MvxViewModel<CityModel>
    {
        CityModel _city;
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
