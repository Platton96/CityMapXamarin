using CityMapXamarin.Core.Models;
using MvvmCross.Core.ViewModels;
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

        public override async Task Initialize(CityModel parameter)
        {
            await base.Initialize();

        }

        public void Init(CityModel obj)
        {

        }

        //public override void Prepare()
        //{
        //    // first callback. Initialize parameter-agnostic stuff here
        //}

        //public override void Prepare(MyObject parameter)
        //{
        //    // receive and store the parameter here
        //    _myObject = parameter;
        //}
    }
}
