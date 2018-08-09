using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Foundation;
using MvvmCross;
using MvvmCross.Converters;
using UIKit;

namespace Blank.Converters
{
    public class TypeToImageStringValueConverter : MvxValueConverter<string, UIImage>
    {
        protected override UIImage Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            UIImage image = null;
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(value);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    image = new UIImage(NSData.FromArray(imageBytes));
                }
            }
            return image;
        }
    }
}