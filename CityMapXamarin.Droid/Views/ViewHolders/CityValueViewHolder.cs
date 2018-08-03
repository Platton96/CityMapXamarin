using System;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using CityMapXamarin.Droid.Infrastructure;

namespace CityMapXamarin.Droid.Views.ViewHolders
{
    public class CityValueViewHolder: MvxRecyclerViewHolder
    {

        private LinearLayout _cityItemCell;
        private TextView _cityName;
        private ImageView _cityImage;
        private Button _cityMapBtn;

        private ShowCityMapDelegate _showCityMap;

        public event EventHandler CityClicked;

        public CityValueViewHolder(View itemView, IMvxAndroidBindingContext context, ShowCityMapDelegate showCityMap) : base (itemView, context)
        {
            _showCityMap=showCityMap;
            InitComponents(itemView);
            ApplyBindings();
        }

        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<CityValueViewHolder, CityModel>();
            bindingSet.Bind(_cityName)
                .For(p => p.Text)
                .To(vm => vm.Name);
            bindingSet.Bind(_cityImage)
                .For(p => p.Drawable)
                .To(vm => vm.ImageUrl).WithConversion("TypeToImageString");

            bindingSet.Apply();
        }

        private void InitComponents(View itemView)
        {
            _cityName = itemView.FindViewById<TextView>(Resource.Id.CityName);
            _cityImage = itemView.FindViewById<ImageView>(Resource.Id.CityIamge);
            _cityItemCell = itemView.FindViewById<LinearLayout>(Resource.Id.cityItemCell);
            _cityMapBtn = itemView.FindViewById<Button>(Resource.Id.button_map_id);

            _cityItemCell.Click += (s, e) =>
            {
                CityClicked(DataContext as CityModel, null);
            };

            _cityMapBtn.Click += (s, e) =>
            {
                var currentItemCity = DataContext as CityModel;
                _showCityMap(currentItemCity);
                
            };
        }
    }
}