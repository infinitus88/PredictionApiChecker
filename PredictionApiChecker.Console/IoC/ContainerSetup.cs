using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictionApiChecker.Data.Access.DAL;
using PredictionApiChecker.Data.Access.DAL.Repositories;
using PredictionApiChecker.Services;
using PredictionApiChecker.Services.PredictionAppService;

namespace PredictionApiChecker.Console.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration config)
        {
            
            AddRepositories(services, config);
            AddAppServices(services);
        }

        private static void AddRepositories(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MainDbContext>(options => {
                options.UseSqlite(config.GetConnectionString("SqliteDbConnection"));
            });

            services.AddScoped<IGenericRepository, GenericRepository>();
        }

        private static void AddAppServices(IServiceCollection services)
        {
            var exampleServiceType = typeof(ExampleAppService);
            var types = (from t in exampleServiceType.GetTypeInfo().Assembly.GetTypes()
                         where t.Namespace.Contains(exampleServiceType.Namespace) && t.Namespace != exampleServiceType.Namespace
                            && t.GetTypeInfo().IsClass
                            && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
                         select t).ToArray();

            foreach (var type in types)
            {
                var interfaceService = type.GetTypeInfo().GetInterfaces().First();
                services.AddScoped(interfaceService, type);
            }

            services.AddHttpClient<PredictionService>(c => 
            {
                c.DefaultRequestHeaders.Add("x-rapidapi-host", "football-prediction-api.p.rapidapi.com");
                c.DefaultRequestHeaders.Add("x-rapidapi-key", "7b4fd465a6mshf68edc31dfa3e66p122a6ejsn8dde8d1265a6");
            });
        }
    }
}