using System;
using System.IO;
using Foundation;
using MvvmCross.Converters;
using UIKit;

namespace Blank.Converters
{
    public class ImagePathToImageConverter : MvxValueConverter<string, UIImage>
    {
        protected override UIImage Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var jpegData = NSData.FromFile(Path.Combine(docsPath, value));
            if (jpegData == null)
            {
                return null;
            }

            return UIImage.LoadFromData(jpegData);
        }
    }
}