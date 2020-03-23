using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int DayNumber  { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string Recommendation
        { get
            {
                string message = "";
                if (Forecast == "snow")
                {
                    message = "Pack snowshoes. ";
                }
                else if (Forecast == "rain")
                {
                    message = "Pack Raingear and waterproof shoes. ";
                }
                else if (Forecast == "thunderstorms")
                {
                    message = "Seek shelter and avoid hiking on exposed ridges. ";
                }
                else if (Forecast == "sunny")
                {
                    message = "Pack sunblock. ";
                }

                if(High > 75)
                {
                    message += "Bring an extra gallon of water. ";
                }

                if(High - Low > 20)
                {
                    message += "Wear clothing that has breathable layers. ";
                }

                if(Low < 20)
                {
                    message += "Beware! It is very cold continue at your own risk!! You may die or get hypothermia and your fingers may fall off! ";
                }
                return message;
            }
                
                
        }
    }
}
