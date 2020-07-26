using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Brokerage.Controllers.Resources
{
    public class CityResource
    {
        public ICollection<KeyValuePairResource> Locations { get; set; }
        public CityResource()
        {
            Locations = new Collection<KeyValuePairResource>();
        }
    }
}
