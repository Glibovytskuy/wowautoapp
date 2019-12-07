using Microsoft.Extensions.DependencyInjection;
using WowAutoApp.Services;
using WowAutoApp.Services.Identity.Registration;
using WowAutoApp.Services.Identity.User;
using WowAutoApp.Services.Profile;

namespace wowautoapp.Extensions.StartupExtensions
{
    /// <summary>
    /// Dependency injection configurator for entity services
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add dependency injection for services
        /// </summary>
        /// <param name="services"></param>
        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IVehicleService, VehicleService>();
        }
    }
}