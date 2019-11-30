using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace wowautoapp.Web.Api.Extensions.StartupExtensions
{
    /// <summary>
    /// Dependency injection configurator for swagger
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add swagger configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "WowautoApp API",
                    Description = "Performance management system",
                    TermsOfService = "None"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}