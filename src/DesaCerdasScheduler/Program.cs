using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using DesaCerdasScheduler.Repositories;

namespace DesaCerdasScheduler
{
    public class Program
    {
        static void Main(string[] args)
        {
            String[] parameterType = args.FirstOrDefault().Split('=');
            Scheduler.Run(int.Parse(parameterType[1]));
        }


    }
}
