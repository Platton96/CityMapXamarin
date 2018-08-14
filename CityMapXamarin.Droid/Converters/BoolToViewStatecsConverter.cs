using System;
using System.Globalization;
using Android.Views;
using MvvmCross.Converters;

namespace CityMapXamarin.Droid.Converters
{
    public class BoolToViewStatecsConverter : MvxValueConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
            {
                return ViewStates.Visible;
            }

            return ViewStates.Invisible;
        }
    }
}