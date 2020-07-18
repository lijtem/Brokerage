using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsOwner { get; set; }
        public string Code { get; set; }
        public string Transmission { get; set; }
        public string EngineSize { get; set; }
        public string EngineType { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string YearMade { get; set; }

        [Required]
        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public SaveVehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}