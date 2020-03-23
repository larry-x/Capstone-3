using Capstone.Web.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Web.Models;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class UnitTests : BossClass
    {

        [TestMethod]
        public void GetParksTest()
        {
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);
            int rows = GetRowCount("park");
            IList<Park> testList = dao.GetParks();

            Assert.AreEqual(rows, testList.Count);
        }

        [DataTestMethod]
        [DataRow("FRM", "FarmerFarm")]
        [DataRow("AMM", "AmericanFarm")]
        public void GetParkByIdRightNameTest(string code, string name)
        {
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);
            Park park = dao.GetParkById(code);
            Assert.AreEqual(name, park.Name);
        }

        [DataTestMethod]
        [DataRow("FRM")]
        [DataRow("AMM")]
        public void GetWeatherTest(string code)
        {
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);
            IList<Weather> testList = dao.GetWeather(code);
            Assert.AreEqual(1, testList.Count);
        }

        [TestMethod]
        public void GetParksDropdownTest()
        {
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);
            int rows = GetRowCount("park");
            IDictionary<string, string> testDictionary = dao.GetParksDropdown();
            Assert.AreEqual(rows, testDictionary.Count);
        }

        [TestMethod]
        public void SaveSurveyTest()
        {
            ParkSqlDAO dal = new ParkSqlDAO(connectionString);
            int initialRowCount = GetRowCount("survey_result");

            Survey survey = new Survey
            {
                Code = "AMM",
                EmailAddress = "hello.world@mail.com",
                State = "OH",
                ActivityLevel = "Active"
            };

            dal.SaveSurvey(survey);

            int finalRowCount = GetRowCount("survey_result");
            Assert.AreEqual(initialRowCount + 1, finalRowCount);
        }

        [TestMethod]
        public void SaveSurveyShouldFailIfParkCodeInvalid()
        {
            ParkSqlDAO dal = new ParkSqlDAO(connectionString);
            int initialRowCount = GetRowCount("survey_result");
            Survey survey = new Survey
            {
                Code = "XYZ",
                EmailAddress = "hello.world@mail.com",
                State = "OH",
                ActivityLevel = "Active"
            };
            dal.SaveSurvey(survey);
            int finalRowCount = GetRowCount("survey_result");
            Assert.AreEqual(initialRowCount, finalRowCount);
        }

        [DataTestMethod]
        [DataRow("FRM", 1)]
        [DataRow("AMM", 1)]
        public void SurveyResultsTest(string code, int count)
        {
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);
            IDictionary<string, int> testDictionary = dao.SurveyResults();

            Assert.AreEqual(count, testDictionary[code]);
        }
    }
}
