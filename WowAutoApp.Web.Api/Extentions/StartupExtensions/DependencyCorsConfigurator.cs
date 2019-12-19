using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace wowautoapp.Extentions.StartupExtensions
{
    /// <summary>
    /// Dependency CORS configurator
    /// </summary>
    public static partial class DependencyCorsConfigurator
    {
        /// <summary>
        /// Add CORS config
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            var policyName = configuration.GetValue<string>("CorsPolicyName");
            var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                {
                    builder.WithOrigins(allowedOrigins)
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(policyName));
            });
        }
    }
}