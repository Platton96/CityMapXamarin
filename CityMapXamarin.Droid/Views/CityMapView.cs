using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using System.Collections.Generic;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Map")]
    public class CityMapView :  MvxActivity<CityMapViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _googleMap;
        public IEnumerable<CityModel> DataCities { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ApplyBindings();
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
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<CityMapView, CityMapViewModel>();
            bindingSet.Bind(this).For(b => b.DataCities).To(vm => vm.Cities);
            bindingSet.Apply();
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;
            AddMarkersInMap();
        }
        
        private void AddMarkersInMap()
        {
            foreach (var city in DataCities)
            {
                var latlng = new LatLng(city.Latitude, city.Longitude);
                var options = new MarkerOptions().SetPosition(latlng).SetTitle(city.Name);
                _googleMap.AddMarker(options);
            }
        }
    }
}
