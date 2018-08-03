using System;
using System.Runtime.Remoting.Contexts;
using Android.App;
using Android.Content;
using Android.Runtime;
using CityMapXamarin.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<MvxAndroidSetup<AppStart>, AppStart>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}