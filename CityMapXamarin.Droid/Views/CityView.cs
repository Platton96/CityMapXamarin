﻿using Android.App;
using Android.OS;
using Android.Widget;
using CityMapXamarin.Core.ViewModels;
using CityMapXamarin.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "City")]
    public class CityView : MvxActivity<CityViewModel>
    {
        private ImageView _cityImage;
        private TextView _cityDescription;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CityPage);
            InitComponents();
            ApplyBindings();
        }

        private void InitComponents()
        {
            _cityImage = FindViewById<ImageView>(Resource.Id.image_city_details);
            _cityDescription = FindViewById<TextView>(Resource.Id.text_city_description);
        }

        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<CityView, CityViewModel>();
            bindingSet.Bind(_cityImage).For(b => b.Drawable).To(vm => vm.City.FilePath).WithConversion<ImagePathToDrawableConverter>();
            bindingSet.Bind(_cityDescription).For(b => b.Text).To(vm => vm.City.Description);

            bindingSet.Apply();
        }
    }
}