using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DesaCerdasScheduler.Helpers
{
    public class CalculationHelper
    {
        public static decimal convertKelvinToCelcius(string temp)
        {
            decimal calculation = decimal.Parse(temp.Replace(".", ",")) - decimal.Parse("273,15");
            return Math.Round(calculation);
        }

        public static decimal parseToDecimal(string temp)
        {
            decimal calculation = decimal.Parse(temp, CultureInfo.InvariantCulture);
            return calculation;
        }
    }

}
