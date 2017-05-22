using System.Data.Entity;

namespace SensorIS.WebApi.Models
{
    public class SensorsContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}