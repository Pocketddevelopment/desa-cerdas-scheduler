using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using DesaCerdasScheduler.Models;

namespace DesaCerdasScheduler.Helpers
{
    public class JSONHelper
    {
        public static T CreateObject<T>(string json)
        {
            return (T)JsonConvert.DeserializeObject(json, typeof(T));
        }
    }
}
