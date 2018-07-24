using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CityMapXomarin.Core.Models
{
    [DataContract]
    public class Data
    {
        [DataMember(Name = "photos")]
        public IEnumerable<CityModel> Cities { get; set; }
    }
}
