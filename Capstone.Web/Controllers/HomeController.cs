using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkDAO parkDAO;

        public HomeController(IParkDAO parkDAO)
        {
            this.parkDAO = parkDAO;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string id = "GNP")
        {
            ParkViewModel model = new ParkViewModel();
            model.MyPark = parkDAO.GetParkById(id);
            model.ThisWeekWeather = parkDAO.GetWeather(id);
            model.TemperatureModeIsF = GetSession();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TConversion(ParkViewModel model)
        {
            bool temperature = GetSession();
            temperature = !temperature;
            SaveSession(temperature);
            return RedirectToAction("Detail", new { id = model.MyPark.Code });
        }

        [HttpGet]
        public IActionResult Survey()
        {
            Survey survey = new Survey();
            IDictionary<string, string> parks = parkDAO.GetParksDropdown();
            survey.PopulateParkDropdown(parks);
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                IDictionary<string, string> parks = parkDAO.GetParksDropdown();
                survey.PopulateParkDropdown(parks);
                return View(survey);
            }

            parkDAO.SaveSurvey(survey);
            return RedirectToAction("Favorites");
        }

        public IActionResult Favorites()
        {
           IDictionary<Park, int> listOfFavorites = new Dictionary<Park, int>();
           IDictionary<string,int> results = parkDAO.SurveyResults();

            foreach(KeyValuePair<string, int> kvp in results)
            {
               listOfFavorites.Add(parkDAO.GetParkById(kvp.Key), kvp.Value) ;
            }
            return View(listOfFavorites);
        }

        private void SaveSession(bool temp)
        {
            HttpContext.Session.Set("CF", temp);
        }

        private bool GetSession()
        {
            bool temp;
            if (HttpContext.Session.Get<bool?>("CF") == null)
            {
                temp = true;
                SaveSession(temp);
            }
            else
            {
                temp = HttpContext.Session.Get<bool>("CF");
            }
            return temp;
        }

    }
}