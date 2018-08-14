using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace CityMapXamarin.Core
{
    public static class SettingsManager
    {
        private const string CitiesKey = "access_cities";
        private const string LastLoginTimeKey = "access_last_login_time";

        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        public static string CititiesData
        {
            get { return AppSettings.GetValueOrDefault(CitiesKey, string.Empty); }
            set { AppSettings.AddOrUpdateValue(CitiesKey, value); }
        }
        public static DateTime LastLoginTime
        {
            get { return AppSettings.GetValueOrDefault(LastLoginTimeKey,DateTime.MinValue); }
            set { AppSettings.AddOrUpdateValue(LastLoginTimeKey, value); }
        }
    }
}
