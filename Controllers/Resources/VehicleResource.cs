using Brokerage.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Model { get; set; }
        public KeyValuePairResource Make { get; set; }
        public bool IsOwner { get; set; }
        //public bool IsRegistered { get; set; }       
        public ContactResource Contact { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Transmission { get; set; }
        public string EngineSize { get; set; }
        public string EngineType { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string YearMade { get; set; }
        public ICollection<KeyValuePairResource> Features { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public VehicleResource()
        {
            Features = new Collection<KeyValuePairResource>();
            Photos = new Collection<Photo>();
        }
    }
}
