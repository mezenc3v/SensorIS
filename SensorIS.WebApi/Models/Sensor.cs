using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorIS.WebApi.Models
{
    public class Sensor
    {
        [Key]
        public int SensorId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}