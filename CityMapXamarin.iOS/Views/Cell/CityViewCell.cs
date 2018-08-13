using System;
using CityMapXamarin.Core.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views.Cell
{
    public partial class CityViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("CityViewCell");
        public static readonly UINib Nib;

        static CityViewCell()
        {
            Nib = UINib.FromName("CityViewCell", NSBundle.MainBundle);
        }

        protected CityViewCell(IntPtr handle) : base(handle)
        {
            BackgroundColor = UIColor.Red;
            InitialiseBindings();
        }
        private void InitialiseBindings()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<CityViewCell, CityModel>();
                set.Bind(CityNameText).For(t => t.Text).To(vm => vm.Name);
              //  set.Bind(CityImage).For(t => t.Image).To(vm => vm.ImageUrl).WithConversion("TypeToImageString");
                set.Apply();
            });
            //var a = CityNameText.Text;
        }
    }
}
