using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android;

namespace CityMapXamarin.Droid.Converters
{
    public class ConverterService
    {
        public Drawable ConvertImageUrlToDrawable(string imageUrl)
        {
            Drawable image = null;
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(imageUrl);
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