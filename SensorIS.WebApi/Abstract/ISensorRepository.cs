using System.Collections.Generic;
using SensorIS.WebApi.Views;

namespace SensorIS.WebApi.Abstract
{
    public interface ISensorsRepository
    {
        IEnumerable<SensorView> Sensors { get; }

        SensorView GetSensor(int sensorId);

        SensorView AddSensor(SensorView sensor);

        void DeleteSensor(int sensorId);
    }
}
