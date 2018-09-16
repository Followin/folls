using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Folls.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config
                            .AddJsonFile("cfg/config.json")
                            .AddJsonFile($"cfg/config.{hostingContext.HostingEnvironment.EnvironmentName}.json")
                            .AddEnvironmentVariables();
                    })
                .UseStartup<Startup>();
    }
}