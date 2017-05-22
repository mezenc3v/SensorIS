using System.Collections.Generic;
using System.Linq;
using SensorIS.WebApi.Abstract;
using SensorIS.WebApi.Views;

namespace SensorIS.WebApi.Models
{
    public class SensorsRepository:ISensorsRepository
    {
        readonly SensorsContext _context = new SensorsContext();

        public IEnumerable<SensorView> Sensors => _context.Sensors.Select(sensor=> new SensorView
        {
            SensorId = sensor.SensorId,
            CategoryId = sensor.CategoryId,
            Description = sensor.Description,
            DescriptionUrl = sensor.DescriptionUrl,
            ImageUrl = sensor.ImageUrl,
            Name = sensor.Name
        });

        public SensorView GetSensor(int id)
        {
            var sensor = _context.Sensors.FirstOrDefault(p => p.SensorId == id);

            var sensorView = new SensorView
            {
                SensorId = sensor.SensorId,
                CategoryId = sensor.CategoryId,
                DescriptionUrl = sensor.DescriptionUrl,
                ImageUrl = sensor.ImageUrl,
                Description = sensor.Description,
                Name = sensor.Name
            };

            return sensorView;
        }

        public SensorView AddSensor(SensorView sensor)
        {
            var newSensor = new Sensor
            {
                CategoryId = sensor.CategoryId,
                ImageUrl = sensor.ImageUrl,
                DescriptionUrl = sensor.DescriptionUrl,
                Description = sensor.Description,
                Name = sensor.Name
            };
            _context.Sensors.Add(newSensor);
            _context.SaveChanges();
            sensor.SensorId = _context.Sensors.First(s => s.Name == sensor.Name).SensorId;
            return sensor;
        }

        public void DeleteSensor(int sensorId)
        {
            var sensorToBeDeleted = _context.Sensors.First(sens => sens.SensorId == sensorId);
            _context.Sensors.Remove(sensorToBeDeleted);
            _context.SaveChanges();
        }
    }
}