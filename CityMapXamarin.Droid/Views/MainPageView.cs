using Android.App;
using Android.OS;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Main page", MainLauncher = true)]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainPage);

        }
    }
}