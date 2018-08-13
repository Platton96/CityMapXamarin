using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace CityMapXamarin.Droid.Converters
{
    public class ImagePathToDrawableConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Drawable image = null;
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var decodedByte = BitmapFactory.DecodeFile($"{currentActivity.FilesDir}/{value}");
            image = new BitmapDrawable(currentActivity.Resources, decodedByte);

            return image;
        }
    }
}