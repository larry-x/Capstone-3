using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkViewModel
    {
        public Park MyPark { get; set; }
        public IList<Weather> ThisWeekWeather { get; set; }
        public bool TemperatureModeIsF { get; set; }
    }
}
