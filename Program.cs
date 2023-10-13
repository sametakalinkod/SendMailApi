using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMailApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                  Host.CreateDefaultBuilder(args)
                      .ConfigureWebHostDefaults(webBuilder =>
                      {
                          //webBuilder.UseUrls("http://localhost:5188/", "http://192.168.40.134:5010");
                          webBuilder.UseStartup<Startup>();
                          //webBuilder.UseStartup<Startup>();
                      });

    }
}
