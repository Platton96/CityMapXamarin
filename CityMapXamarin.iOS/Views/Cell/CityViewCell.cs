using System;

using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views.Cell
{
    public partial class CityViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("CityViewCell");
        public static readonly UINib Nib;

        static CityViewCell()
        {
            Nib = UINib.FromName("CityViewCell", NSBundle.MainBundle);
        }

        protected CityViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
