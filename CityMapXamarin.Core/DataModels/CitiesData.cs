using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CityMapXamarin.Core.DataModels
{
    [DataContract]
    public class CitiesData
    {
        [DataMember(Name = "photos")]
        public IEnumerable<CityData> Cities { get; set; }
    }
}
