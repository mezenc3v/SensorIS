using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorIS.WebApi.Views
{
    public class SensorView
    {
        public int SensorId;
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string DescriptionUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}