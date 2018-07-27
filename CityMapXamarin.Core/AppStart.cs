using CityMapXamarin.Core.Infastrucure;
using CityMapXamarin.Core.Services;
using CityMapXamarin.Core.Services.Api;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CityMapXamarin.Core
{
    public class AppStart : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<ICitiesService, CitiesService>();
            Mvx.LazyConstructAndRegisterSingleton<ICitiesApiService, CitiesApiService>();
            RegisterAppStart<MainPageViewModel>();
        } 
    }
}
