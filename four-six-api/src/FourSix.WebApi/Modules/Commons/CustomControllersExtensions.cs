using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FourSix.WebApi.Modules.Commons
{
    public static class CustomControllersExtensions
    {
        /// <summary>
        ///     Add Custom Controller dependencies.
        /// </summary>
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services
                .AddHttpContextAccessor()
                .AddMvc(options =>
                {
                    options.OutputFormatters.RemoveType<TextOutputFormatter>();
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.RespectBrowserAcceptHeader = true;
                    options.Filters.Add(new ExceptionFilter());
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                })
                .AddControllersAsServices();

            return services;
        }
    }
}