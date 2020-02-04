using Microsoft.Extensions.DependencyInjection;
using WowAutoApp.Core;
using WowAutoApp.Services.Identity.Auth;
using wowautoapp.Infrastructure;

namespace wowautoapp.Extensions.StartupExtensions
{
    /// <summary>
    /// Dependency injection for web configurator
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add web configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddWebConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IWorkContext, WebWorkContext>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
