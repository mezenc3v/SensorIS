using System.ComponentModel.DataAnnotations;

namespace SensorIS.WebApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}