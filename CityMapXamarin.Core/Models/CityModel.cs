using System.Runtime.Serialization;

namespace CityMapXomarin.Core.Models
{
    [DataContract]
    public class CityModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "title")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "url")]
        public string ImageUrl { get; set; }
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
    }
}
