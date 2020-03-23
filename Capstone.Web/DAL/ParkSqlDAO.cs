using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string ConnectionString;

        public ParkSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park ORDER BY parkName", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        parks.Add(MapPropToObject(reader));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return parks;
        }

        private Park MapPropToObject(SqlDataReader reader)
        {
            Park park = new Park
            {
                Code = Convert.ToString(reader["parkCode"]),
                Name = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                TrailMiles = Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToDouble(reader["annualVisitorCount"]),
                Quote = Convert.ToString(reader["inspirationalQuote"]),
                QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                Description = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };

            return park;
        }

        public Park GetParkById(string code)
        {

            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @code", conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park = MapPropToObject(reader);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return park;
        }

        public IList<Weather> GetWeather(string code)
        {
            IList<Weather> weather = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @code", conn);
                    cmd.Parameters.AddWithValue("@code", code);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weatherPerDay = new Weather
                        {
                            DayNumber = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"])
                        };
                        weather.Add(weatherPerDay);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return weather;
        }

        public IDictionary<string, string> GetParksDropdown()
        {
            IDictionary<string, string> parks = new Dictionary<string, string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT parkCode, parkName  FROM park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string code = Convert.ToString(reader["parkCode"]);
                        string name = Convert.ToString(reader["parkName"]);

                        parks.Add(code, name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return parks;
        }

        public void SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES(@code, @email, @state, @activity)", conn);

                    cmd.Parameters.AddWithValue("@code", survey.Code);
                    cmd.Parameters.AddWithValue("@email", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activity", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IDictionary<string, int> SurveyResults()
        {

            IDictionary<string, int> results = new Dictionary<string, int>();
        
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(parkCode) as numberOfReviews, parkCode FROM survey_result GROUP BY parkCode ORDER BY numberOfReviews DESC, parkCode", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string code = Convert.ToString(reader["parkCode"]);
                        int count = Convert.ToInt32(reader["numberOfReviews"]);
                        results.Add(code, count);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;
        }

    }
}
