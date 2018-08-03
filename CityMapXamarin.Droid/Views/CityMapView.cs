using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.ViewModels;
using MvvmCross;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Map")]
    public class CityMapView :  MvxActivity<CityMapViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _googleMap;
        private ICitiesService _citiesService;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _citiesService = Mvx.Resolve<ICitiesService>();
            SetContentView(Resource.Layout.CityMapPage);
            SetUpMap();
        }
        private void SetUpMap()
        {
            if (_googleMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;

            foreach (var city in _citiesService.Cities)
            {
                var latlng = new LatLng(city.Latitude, city.Longitude);
                var options = new MarkerOptions().SetPosition(latlng).SetTitle(city.Name);
                _googleMap.AddMarker(options);
            }
        }
    }
}