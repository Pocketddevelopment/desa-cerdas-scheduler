using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesaCerdasScheduler.Helpers;
using System.Configuration;
using System.Net;
using DesaCerdasScheduler.Repositories;
using System.Data.SqlClient;
using Newtonsoft.Json;
using DesaCerdasScheduler.Models;
using System.Globalization;

namespace DesaCerdasScheduler.Logic
{
    public interface IWeatherLogic
    {
        void GetWeatherData();
    }


    public class WeatherServices
    {
        public static void GetWeatherData()
        {
            FinalModelGetWeather weatherModel = new FinalModelGetWeather();
            string openWeatherKey = ConfigurationManager.AppSettings["Open_Weather_Key"];
            string url = ConfigurationManager.AppSettings["Open_Weather_Url"];
            var listDistricts = Repositories.DistrictRepository.GetAllDistrict();

            #region filterdate
            DateTime now = DateTime.Now;
            //enddate roundownhour, ex from 17.40 to 17.00
            DateTime EndDate = now.AddMinutes(-now.Minute).AddSeconds(-now.Second);
            //stardate from today 00.00
            DateTime startDate = EndDate.AddHours(-now.Hour);

            DateTimeOffset sdt = new DateTimeOffset(startDate);
            string unixstartTime = sdt.ToUnixTimeSeconds().ToString();

            DateTimeOffset edt = new DateTimeOffset(EndDate);
            string unixendTime = edt.ToUnixTimeSeconds().ToString();
            #endregion

            try
            {
                foreach (var dist in listDistricts)
                {
                    if (dist.Longitude != "" && dist.Latitude != "")
                    {
                        weatherModel.DistrictID = Guid.Parse(dist.ID);
                        #region get Weather
                        string urlWeather = url + "/weather" + "?lat=" + dist.Latitude + "&lon=" + dist.Longitude + "&appid=" + openWeatherKey;
                        using (WebClient client = new WebClient())
                        {
                            var downloadString = client.DownloadString(urlWeather);
                            if (downloadString != null)
                            {
                                var responseWeather = JSONHelper.CreateObject<WeatherModel>(downloadString);
                                if (responseWeather != null)
                                {
                                    weatherModel.Temp_Min = CalculationHelper.convertKelvinToCelcius(responseWeather.main.temp_min);
                                    weatherModel.Temp_Max = CalculationHelper.convertKelvinToCelcius(responseWeather.main.temp_max);
                                    weatherModel.Humidity = CalculationHelper.parseToDecimal(responseWeather.main.humidity);
                                    weatherModel.WindVelocity = CalculationHelper.parseToDecimal(responseWeather.wind.speed);
                                    weatherModel.WindDegrees = CalculationHelper.parseToDecimal(responseWeather.wind.deg);
                                    weatherModel.Weather = responseWeather.weather.FirstOrDefault().main;
                                    weatherModel.WeatherDesc = responseWeather.weather.FirstOrDefault().description;
                                }
                            }
                        }
                        #endregion

                        #region get AirPollution
                        string urlAirPollution = url + "/air_pollution/history" + "?lat=" + dist.Latitude + "&lon=" + dist.Longitude + "&appid=" + openWeatherKey + "&start=" + unixstartTime + "&end=" + unixendTime;
                        using (WebClient client = new WebClient())
                        {
                            var downloadString = client.DownloadString(urlAirPollution);
                            if (downloadString != null)
                            {
                                var responseAirPollution = JSONHelper.CreateObject<ListResponseAirPollutionModel>(downloadString);
                                if (responseAirPollution != null)
                                {
                                    var data = getPollutionAverage(responseAirPollution);
                                    if (data != null)
                                    {
                                        weatherModel.Aqi = data.aqi;
                                        weatherModel.Co = data.co;
                                        weatherModel.O3 = data.o3;
                                        weatherModel.No2 = data.no2;
                                        weatherModel.pm10 = data.pm10;
                                        weatherModel.pm2_5 = data.pm2_5;
                                        weatherModel.Hour = EndDate.ToString("MM/dd/yyyy HH:mm");

                                    }
                                }
                            }
                        }
                        #endregion

                        #region insert DB
                        int rowAffected = AirPollutionRepository.Insert(weatherModel);
                        #endregion
                    }
                }
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.Message);
            }
        }

        public static tempAirPollutionModel getPollutionAverage(ListResponseAirPollutionModel data)
        {
            tempAirPollutionModel resp = new tempAirPollutionModel();
            resp.co = 0;
            resp.no2 = 0;
            resp.o3 = 0;
            resp.pm2_5 = 0;
            resp.pm10 = 0;
            resp.aqi = 0;
            if (data != null && data.list.Count() > 0)
            {
                foreach (var item in data.list)
                {
                    resp.co = resp.co + CalculationHelper.parseToDecimal(item.components.co);
                    resp.no2 = resp.no2 + CalculationHelper.parseToDecimal(item.components.no2);
                    resp.o3 = resp.o3 + CalculationHelper.parseToDecimal(item.components.o3);
                    resp.pm2_5 = resp.pm2_5 + CalculationHelper.parseToDecimal(item.components.pm2_5);
                    resp.pm10 = resp.pm10 + CalculationHelper.parseToDecimal(item.components.pm10);
                    resp.aqi = resp.aqi + CalculationHelper.parseToDecimal(item.main.aqi);
                }

                resp.co = Decimal.Round((resp.co / data.list.Count()));
                resp.no2 = Decimal.Round((resp.no2 / data.list.Count()));
                resp.o3 = Decimal.Round((resp.o3 / data.list.Count()));
                resp.pm2_5 = Decimal.Round((resp.pm2_5 / data.list.Count()));
                resp.pm10 = Decimal.Round((resp.pm10 / data.list.Count()));
                resp.aqi = Decimal.Round((resp.aqi / data.list.Count()));
            }
            return resp; 
        }
    }
}
