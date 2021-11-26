using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using dashboard;
using Microsoft.Extensions.Logging.EventLog;

namespace dashboard.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                            .ConfigureLogging((hostingContext, logging) =>
                            {
                              //  logging.ClearProviders();
                                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                                //logging.AddEventLog(new EventLogSettings()
                                //{
                                //    SourceName = "SomeApi",
                                //    LogName = "SomeApi",

                                //    // Filter = (x, y) => y >= LogLevel.Information
                                //});
                                logging.AddConsole();
                            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
