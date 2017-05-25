using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SensorIS.WebApi.Abstract;
using SensorIS.WebApi.Models;
using SensorIS.WebApi.Views;

namespace SensorIS.WebApi.Controllers
{
    [RoutePrefix("api/v1/sensors")]
    [EnableCors("*", "*", "*")]
    public class SensorsController : ApiController
    {
        private readonly ISensorsRepository _repository;

        public SensorsController(ISensorsRepository repo)
        {
            _repository = repo;
        }

        public SensorsController()
        {
            _repository = new SensorsRepository();
        }
        /// <summary>
        /// Get all sensors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<SensorView> GetSensors()
        {
            return _repository.Sensors;
        }

        /// <summary>
        /// Get a specific sensor
        /// </summary>
        /// <param name="id">sensor id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public SensorView GetSensor(int id)
        {
            return _repository.GetSensor(id);
        }
        /// <summary>
        /// create sensor
        /// </summary>
        /// <param name="sensor">the sensor you want to create</param>
        /// <returns>created sensor</returns>
        [HttpPost]
        [Route("")]
        public SensorView AddSensor([FromBody]SensorView sensor)
        {
            var newSensor = _repository.AddSensor(sensor);
            return newSensor;
        }

        /// <summary>
        /// delete sensor
        /// </summary>
        /// <param name="sensorId">the sensor id you want to delete</param>
        [HttpDelete]
        [Route("{sensorId}")]
        public void DeleteCategory(int sensorId)
        {
            _repository.DeleteSensor(sensorId);
        }
    }
}