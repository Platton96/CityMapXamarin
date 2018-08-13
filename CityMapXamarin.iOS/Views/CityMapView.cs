using System.Collections.Generic;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Core.ViewModels;
using CoreLocation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
    public class CityMapView : MvxViewController<CityMapViewModel>
    {
        private UIView _mainView;
        private MKMapView _map;
        public IEnumerable<CityModel> Cities { get; set; }
        public CityMapView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitComponents();
            ApplyBindings();
            AddMarckers();
        }
        private void InitComponents()
        {

            _mainView = new UIView(View.Bounds);
            _mainView.BackgroundColor = UIColor.White;
            View.AddSubview(_mainView);

            _map = new MKMapView(UIScreen.MainScreen.Bounds);
            _map.SetCenterCoordinate(new CLLocationCoordinate2D(57, 37), false);
            _mainView.AddSubview(_map);
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<CityMapView, CityMapViewModel>();
            bindingSet.Bind(this).For(b => b.Cities).To(vm => vm.Cities);
            bindingSet.Apply();
        }

        private void AddMarckers()
        {
            foreach (var city in Cities)
            {
                _map.AddAnnotation(new MKPointAnnotation()
                {
                    Title = city.Name,
                    Coordinate = new CLLocationCoordinate2D(city.Latitude, city.Longitude)
                });
            }
        }
    }
}