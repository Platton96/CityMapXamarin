using CityMapXamarin.Core.Infastrucure;
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
            base.Initialize();

            Mvx.ConstructAndRegisterSingleton<ICitiesService, CitiesService>();
            Mvx.ConstructAndRegisterSingleton<ICitiesApiService, CitiesApiService>();
            RegisterAppStart<MainPageViewModel>();
        } 
    }
}
