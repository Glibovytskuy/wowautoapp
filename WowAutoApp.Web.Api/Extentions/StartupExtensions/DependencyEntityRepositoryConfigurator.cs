using Microsoft.Extensions.DependencyInjection;
using WowAutoApp.Core.Domain;
using WowAutoApp.Core.Domain.Profile;
using WowAutoApp.Core.Repo;
using WowAutoApp.Data;

namespace wowautoapp.Extentions.StartupExtensions
{
    /// <summary>
    /// Dependency injection configurator for entity repositories
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add dependency injection for repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddEntityRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<ApplicationUser>, EfRepository<ApplicationUser>>();
            services.AddTransient<IRepository<Profile>, EfRepository<Profile>>();
        }
    }
}