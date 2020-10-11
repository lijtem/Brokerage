using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Core.Models
{
    public class Remark
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public int VehicleId { get; set; }
    }
}
