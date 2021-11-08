using System.ComponentModel.Design;
using System.IO;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using PredictionApiChecker.Console.IoC;
using System.Threading.Tasks;

namespace PredictionApiChecker.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = AppStartup();

            var consoleApp = ActivatorUtilities.CreateInstance<ConsoleAppService>(host.Services);

            await consoleApp.Run();
        }

        static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            ConfigSetup(builder);

            // defining Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();


            // Initiating the dependency injection container
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) => 
                        {
                            ContainerSetup.Setup(services, builder.Build());
                            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                        })
                        .UseSerilog()
                        .Build();

            return host;
        }
    }
}
