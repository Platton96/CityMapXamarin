using System;
using Foundation;
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
        public UILabel Name
        {
            get => CityNameText;
            set { CityNameText = value; }
        }
        public UIImageView ImageView
        {
            get => CityImage;
            set { CityImage = value; }
        }
        protected CityViewCell(IntPtr handle) : base(handle)
        {
        }
    }
}