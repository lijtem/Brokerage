using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brokerage.Core.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsOwner { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }
        [StringLength(255)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdate { get; set; }
        [StringLength(50)]
        public string Transmission { get; set; }
        [StringLength(50)]
        public string EngineSize { get; set; }
        [StringLength(50)]
        public string EngineType { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public string Price { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string YearMade { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
            Photos = new Collection<Photo>();
        }
    }
}
