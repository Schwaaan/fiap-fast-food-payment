using FourSix.Controllers.Gateways.Integrations;
using FourSix.UseCases.Interfaces;

namespace FourSix.WebApi.Modules
{
    public static class IntegrationsExtensions
    {
        public static IServiceCollection AddIntegrations(this IServiceCollection services)
        {
            services.AddScoped<IOrderIntegrationService, OrderIntegrationService>();

            return services;
        }
    }
}
