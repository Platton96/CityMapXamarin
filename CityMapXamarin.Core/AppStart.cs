using CityMapXamarin.Core.Infastrucure;
using CityMapXamarin.Core.Services;
using CityMapXamarin.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core
{
    public class AppStart : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<ICitiesService, CitiesService>();
            RegisterAppStart<MainPageViewModel>();
        } 
    }
}
