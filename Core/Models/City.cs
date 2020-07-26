using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Core.Models
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public ICollection<Location> Locations { get; set; }
        public City()
        {
            Locations = new Collection<Location>();
        }
    }
}
