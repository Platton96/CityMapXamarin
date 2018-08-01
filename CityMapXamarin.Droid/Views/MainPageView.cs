using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Views;
using System.Collections.Generic;
using System.Linq;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Main page", MainLauncher = true)]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainPage);

            var btn = FindViewById<Button>(Resource.Id.button_map_id);
            btn.Click += (s, e) =>
            {
                var citiesList = FindViewById<MvxListView>(Resource.Id.CitiesList);
                var cities = citiesList.ItemsSource as IEnumerable<CityModel>;
                var city= cities.First();
                var geoUri = Android.Net.Uri.Parse($"geo:{city.Latitude},{city.Longitude}?q={city.Latitude},{city.Longitude}(Label+{city.Name})");
                
                var mapIntent = new Intent(Intent.ActionView, geoUri);
                StartActivity(mapIntent);

            };
        }
    }
}