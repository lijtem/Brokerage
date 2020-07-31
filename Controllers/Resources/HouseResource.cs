using Brokerage.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Controllers.Resources
{
    public class HouseResource
    {
        public int Id { get; set; }
        public KeyValuePairResource City { get; set; }
        public KeyValuePairResource Location { get; set; }
        public bool IsOwner { get; set; }
        //public bool IsRegistered { get; set; }       
        public ContactResource Contact { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }
        public string Category { get; set; }
        public string PropertyFor { get; set; }
        public string Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Area { get; set; }
        public int NoFloors { get; set; }
        public string Built { get; set; }
        public ICollection<HousePhoto> Photos { get; set; }

        public HouseResource()
        {
            Photos = new Collection<HousePhoto>();
        }
    }
}
