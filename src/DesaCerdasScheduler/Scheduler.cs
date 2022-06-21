using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesaCerdasScheduler.Helpers;
using DesaCerdasScheduler.Logic;

namespace DesaCerdasScheduler
{
    public class Scheduler
    {
        public static void Run(int schedulerType)
        {
            try
            {
                if (schedulerType == (int)Constant.SchedulerTypeEnum.WeatherScheduler)
                {
                    Logic.WeatherServices.GetWeatherData();
                }
                else if (schedulerType == 2)
                {
                    Console.WriteLine("Hello World2!");
                }

            }
            catch (Exception)
            {
                //error
            }
        }
    }
}
