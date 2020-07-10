using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../WebApplication1/WebApplication1"))
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();


            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../../WebApplication1");
            var dict = Directory.GetCurrentDirectory();
            DirectoryInfo info = new DirectoryInfo(path);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
