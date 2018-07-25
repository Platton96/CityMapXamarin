using CityMapXomarin.Core.Infastrucure;
using CityMapXomarin.Core.Services;
using CityMapXomarin.Core.Services.Api;
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
        }
    }
}
