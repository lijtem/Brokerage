using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brokerage.Core.Models
{
    [Table("Locations")]
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}