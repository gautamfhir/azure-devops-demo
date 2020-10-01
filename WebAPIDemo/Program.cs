using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebAPIDemo
{
    public class Program
    {
        static string environment = "";
        public static void Main(string[] args)
        {
            //var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //environment = config.GetSection("Environment").Value;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;
                    config.AddJsonFile("appsettings.json");
                    config.AddJsonFile($"appsettings.{env.EnvironmentName}.json");
                    //config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("Env")}.json");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
