using CityMapXamarin.Core.DataModels;
using MvvmCross;
using System.Runtime.Serialization;

namespace CityMapXamarin.Core.Models
{
    [DataContract]
    public class CityModel : CityData
    {
        [DataMember]
        public string FilePath { get; set; }

        public CityModel() { }
        public CityModel (CityData cityData, string filePath )
        {
            Name = cityData.Name;
            Description = cityData.Description;
            Id = cityData.Id;
            ImageUrl = cityData.ImageUrl;
            Longitude = cityData.Longitude;
            Latitude = cityData.Latitude;
            FilePath = filePath;
        }
    }
}
