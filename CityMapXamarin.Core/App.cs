using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Services;
using CityMapXamarin.Core.Services.Api;
using CityMapXamarin.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<ICitiesService, CitiesService>();
            Mvx.LazyConstructAndRegisterSingleton<ICitiesApiService, CitiesApiService>();
            Mvx.LazyConstructAndRegisterSingleton<INavigationManager, NavigationManager>();
            RegisterAppStart<LoginViewModel>();
        } 
    }
}
