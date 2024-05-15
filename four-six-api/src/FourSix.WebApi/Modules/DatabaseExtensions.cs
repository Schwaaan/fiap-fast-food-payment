using FourSix.Controllers.Gateways.DataAccess;
using FourSix.Controllers.Gateways.Repositories;
using FourSix.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using System.Security.Authentication;

namespace FourSix.WebApi.Modules
{
    public static class DatabaseExtensions
    {
        static string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{envName}.json", true)
            .AddEnvironmentVariables()
            .Build();

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(ReadDefaultConnectionStringFromAppSettings("PersistenceModule:SQLServerConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<DbContext, Context>();

            return services;
        }

        private static string ReadDefaultConnectionStringFromAppSettings(string value)
        {
            string connectionString = configuration.GetValue<string>(value);
            return connectionString;
        }
    }

}
