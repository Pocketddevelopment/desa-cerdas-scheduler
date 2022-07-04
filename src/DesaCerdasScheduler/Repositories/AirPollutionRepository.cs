using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using DesaCerdasScheduler.Models;

namespace DesaCerdasScheduler.Repositories
{

    public class AirPollutionRepository
    {
        static string ConnectionStrings = ConfigurationManager.ConnectionStrings["DesaCerdas_ContentEntities"].ToString();
        public static int Insert(FinalModelGetWeather model)
        {
            SqlConnection sqlconnection;
            try
            {
                sqlconnection = new SqlConnection(ConnectionStrings);
                sqlconnection.Open();
                string insertQuery = "INSERT INTO AirPollution(ID, DistrictID, Weather, WeatherDesc, TemperatureMin, TemperatureMax,"
                    + "Humidity, WindVelocity, WindDegrees, AirQualityIndex, CarbonRate, OzoneRate, NitrogenRate, FineParticles, CoarseParticles,"
                    + "UviIndex, Hour, IsDeleted, Created, CreatedBy)"
                    + "VALUES('" + Guid.NewGuid() + "','" + model.DistrictID + "','" + model.Weather + "','" + model.WeatherDesc
                    + "','" + model.Temp_Min.ToString().Replace(",",".") + "','" + model.Temp_Max.ToString().Replace(",", ".") + "','" 
                    + model.Humidity.ToString().Replace(",", ".") + "','" + model.WindVelocity.ToString().Replace(",", ".") 
                    + "','" + model.WindDegrees.ToString().Replace(",", ".") + "','"
                    + model.Aqi.ToString().Replace(",", ".") + "','" + model.Co.ToString().Replace(",", ".") + "','" + model.O3.ToString().Replace(",", ".") 
                    + "','" + model.No2.ToString().Replace(",", ".") + "','" + model.pm2_5.ToString().Replace(",", ".") + "','" + model.pm10.ToString().Replace(",", ".")
                    + "','" + model.UviIndex.ToString().Replace(",", ".") + "','" + model.Hour + "','" + 0 + "',GETDATE(), 'Scheduler')";
                SqlCommand insertcommand = new SqlCommand(insertQuery, sqlconnection);
                var rowAffected = insertcommand.ExecuteNonQuery();
                sqlconnection.Close();
                return rowAffected;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
