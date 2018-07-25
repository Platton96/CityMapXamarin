using Android.Content;
using CityMapXamarin.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context context) : base()
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}