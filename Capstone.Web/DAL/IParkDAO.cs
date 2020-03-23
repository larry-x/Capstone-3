using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
   public interface IParkDAO
    {
        IList<Park> GetParks();

        

        void SaveSurvey(Survey survey);

        IList<Weather> GetWeather(string code);

        Park GetParkById(string code);

        IDictionary<string, string> GetParksDropdown();

        IDictionary<string, int> SurveyResults();

        
    }
}
