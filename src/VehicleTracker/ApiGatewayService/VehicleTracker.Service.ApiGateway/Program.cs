using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace VehicleTracker.Service.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        //{
        //    var builder = WebHost.CreateDefaultBuilder(args);

        //    builder.ConfigureServices(s => s.AddSingleton(builder))
        //        .ConfigureAppConfiguration(
        //            ic => ic.AddJsonFile(Path.Combine("configuration",
        //                "configuration.json")))
        //        .UseStartup<Startup>();

        //    return builder;
        //}

    }
}
