using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CityMapXamarin.Core
{
    public static class SettingsManager
    {
        private const string AccessCitiesKey = "access_cities";

        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        public static string AccessCitities
        {
            get { return AppSettings.GetValueOrDefault(AccessCitiesKey, string.Empty); }
            set { AppSettings.AddOrUpdateValue(AccessCitiesKey, value); }
        }
    }
}
