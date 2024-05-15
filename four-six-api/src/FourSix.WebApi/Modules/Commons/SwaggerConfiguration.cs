using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;

namespace FourSix.WebApi.Modules.Commons
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            services.AddSwaggerGen(s =>
            {
                s.EnableAnnotations();
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = fvi.ProductVersion,
                    Title = "Four Six API",
                    Description = $"API de integração Four Six 4",
                    Contact = new OpenApiContact
                    {
                        Name = "TI FourSix - Grupo 46"
                    },
                    TermsOfService = null,
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

        }
    }
}
