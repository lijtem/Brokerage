using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Controllers.Resources
{
    public class SaveHouseResource
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
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
        public string Code { get; set; }
        public bool IsOwner { get; set; }

        [Required]
        public ContactResource Contact { get; set; }

    }
}
