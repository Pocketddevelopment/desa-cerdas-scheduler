using System;
using System.Collections.Generic;
using System.Text;

namespace DesaCerdasScheduler.Models
{
    #region response weather for dezerialize
    public class WeatherModel
    {
        public List<Weather> weather { get; set; }

        public Wind wind { get; set; }

        public Main main { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Wind
    {
        public string speed { get; set; }

        public string deg { get; set; }
    }

    public class Main
    {
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string humidity { get; set; }
    }
    #endregion

    #region response air pollution for dezerialize
    public class ListResponseAirPollutionModel
    {
        public List<ResponseAirPollutionModel> list { get; set; }
    }

    public class ResponseAirPollutionModel
    {
        public MainResponse main { get; set; }
        public Components components { get; set; }
    }

    public class MainResponse
    {
        public string aqi { get; set; }
    }

    public class Components
    {
        public string co { get; set; }
        public string no2 { get; set; }
        public string o3 { get; set; }
        public string pm2_5 { get; set; }
        public string pm10 { get; set; }
    }
    #endregion

    public class tempAirPollutionModel
    {
        public decimal aqi { get; set; }
        public decimal co { get; set; }
        public decimal no2 { get; set; }
        public decimal o3 { get; set; }
        public decimal pm2_5 { get; set; }
        public decimal pm10 { get; set; }
    }

    #region model for insert DB
    public class FinalModelGetWeather
    {
        public Guid DistrictID { get; set; }
        public decimal Temp_Min { get; set; }
        public decimal Temp_Max { get; set; }
        public decimal Humidity { get; set; }
        public string Weather { get; set; }
        public string WeatherDesc { get; set; }
        public decimal WindVelocity { get; set; }
        public decimal WindDegrees { get; set; }
        public decimal Aqi { get; set; }
        public decimal Co { get; set; }
        public decimal No2 { get; set; }
        public decimal O3 { get; set; }
        public decimal pm2_5 { get; set; }
        public decimal pm10 { get; set; }
        public string Hour { get; set; }
        public decimal UviIndex { get; set; }

        #endregion
    }

    public class UviModel
    {
        public UviDetailModel current { get; set; }

    }

    public class UviDetailModel
    {
        public decimal uvi { get; set; }

    }
}
