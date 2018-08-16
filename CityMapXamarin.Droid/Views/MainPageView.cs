using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Core.ViewModels;
using CityMapXamarin.Droid.Views.Adapters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Main page")]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private CityValueAdapter _adapter;
        private Button _cityMapBtn;
        private Button _microchartBtn;
        private Button _radialChartBtn;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _adapter = new CityValueAdapter((IMvxAndroidBindingContext)BindingContext, ShowCityMap);

            SetContentView(Resource.Layout.MainPage);
            InitComponents();
            ApplyBindings();

        }
        private void InitComponents()
        {
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.cities_list);
            _recyclerView.Adapter = _adapter;
            _cityMapBtn = FindViewById<Button>(Resource.Id.btn_main_map);
            _microchartBtn = FindViewById<Button>(Resource.Id.btn_chart);
            _radialChartBtn = FindViewById<Button>(Resource.Id.btn_radial_chart);
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<MainPageView, MainPageViewModel>();
            bindingSet.Bind(_adapter).For(b => b.CityItemClick).To(vm => vm.NavigateToCityCommand);
            bindingSet.Bind(_adapter).For(b => b.ItemsSource).To(vm => vm.Cities);
            bindingSet.Bind(_cityMapBtn).To(vm => vm.NavigateToCityMapCommand);
            bindingSet.Bind(_microchartBtn).To(vm => vm.NavigateToMicrochartCommand);
            bindingSet.Bind(_radialChartBtn).To(vm => vm.NavigateToRadialCommand);
            bindingSet.Apply(); 
        }
        private void ShowCityMap(CityModel city)
        {
            var geoUri = Android.Net.Uri.Parse($"geo:{city.Latitude},{city.Longitude}?q={city.Latitude},{city.Longitude}(Label+{city.Name})");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
    }
}