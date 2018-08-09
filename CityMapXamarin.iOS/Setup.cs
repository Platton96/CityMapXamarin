using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Converters;
using CityMapXamarin.Core;
using Foundation;
using MvvmCross.Converters;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace Blank
{
    public class Setup: MvxIosSetup<AppStart>
    {
        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            registry.AddOrOverwrite("TypeToImageString", new TypeToImageStringValueConverter());
            base.FillValueConverters(registry);
        }
    }
}