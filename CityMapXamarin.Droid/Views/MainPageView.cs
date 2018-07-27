using Android.App;
using Android.Content.PM;
using Android.OS;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Main page", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainPage);
        }
    }
}