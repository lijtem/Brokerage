using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Controllers.Resources
{
    public class VehicleQueryResource
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public bool? IsOwner { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string SortBy { get; set; }
        
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
