using Android.App;
using Android.OS;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "City")]
    public class CityView : MvxActivity<CityViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CityPage);
        }
    }
}