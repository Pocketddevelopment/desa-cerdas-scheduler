using System;
using System.Collections.Generic;
using System.Text;

namespace DesaCerdasScheduler.Helpers
{
    public class WeatherHelper
    {
        public static string convertDescToBahasa(string desc)
        {
            if (desc == "clear sky")
            {
                desc = "Langit Cerah";
            }
            else if (desc == "few clouds")
            {
                desc = "Sedikit Berawan";
            }
            else if (desc == "scattered clouds")
            {
                desc = "Awan Tersebar";
            }
            else if (desc == "broken clouds")
            {
                desc = "Awan Pecah";
            }
            else if (desc == "shower rain")
            {
                desc = "Hujan Deras";
            }
            else if (desc == "rain")
            {
                desc = "Hujan";
            }
            else if (desc == "	thunderstorm")
            {
                desc = "Hujan Badai";
            }
            else if (desc == "snow")
            {
                desc = "Bersalju";
            }
            else if (desc == "mist")
            {
                desc = "Berkabut";
            }
            return desc;
        }
    }
}
