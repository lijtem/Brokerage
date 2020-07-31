using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brokerage.Core.Models
{
    [Table("Houses")]
    public class House
    {
        public int Id { get; set; }
        [StringLength(150)]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Category { get; set; }
        public string PropertyFor { get; set; }
        public string Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Area { get; set; }
        public int NoFloors { get; set; }
        public string Built { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }
        [StringLength(255)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        public string Code { get; set; }
        public bool IsOwner { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<HousePhoto> Photos { get; set; }

        public House()
        {
            Photos = new Collection<HousePhoto>();
        }
    }
}
