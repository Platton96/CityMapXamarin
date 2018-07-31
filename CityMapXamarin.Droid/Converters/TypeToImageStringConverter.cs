using System;
using System.Net;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace CityMapXamarin.Droid.Converters
{
    public class TypeToImageStringValueConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Drawable image = null;
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(value);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    var decodedByte = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    image = new BitmapDrawable(currentActivity.Resources, decodedByte);
                }
            }

            return image;
        }
    }
}