using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Controllers.Resources
{
    public class HouseQueryResource
    {
        public int? CityId { get; set; }
        public int? LocationId { get; set; }
        public bool? IsOwner { get; set; }
        public string? Code { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
