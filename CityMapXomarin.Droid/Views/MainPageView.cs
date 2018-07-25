using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using CityMapXomarin.Droid;
using CityMapXamarin.Core.ViewModels;

namespace CrossJournal.UI.Droid.Views
{
    [Activity(Label = "Main page", MainLauncher=true)]
    public class MainPageView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainPage);
        }
    }
}