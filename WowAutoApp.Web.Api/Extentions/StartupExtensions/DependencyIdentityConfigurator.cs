using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using WowAutoApp.Core.Domain;
using WowAutoApp.Data;
using WowAutoApp.Data.Interfaces;
using WowAutoApp.Services.Identity.Auth;
using WowAutoApp.Services.Installation;
using wowautoapp.Infrastructure;

namespace wowautoapp.Extensions.StartupExtensions
{
    /// <summary>
    /// Dependency injection configurator
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add identity configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(configuration.GetConnectionString("AppConnection"), sql => sql.MigrationsAssembly("WowAutoApp.Data"));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(configuration.GetConnectionString("AppConnection"), sql => sql.MigrationsAssembly("WowAutoApp.Data"));

                    // this enables automatic token cleanup. this is optional. 
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                })
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>();

            IdentityModelEventSource.ShowPII = true;

            services.AddTransient<IDbContext, ApplicationDbContext>();
            services.AddTransient<ISeedSerivce, SeedService>();
        }

        /// <summary>
        /// Seed database
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="serviceProvider"></param>
        public static void SeedDatabase(this IApplicationBuilder builder, IServiceProvider serviceProvider)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                dbContext.Database.EnsureCreated();

                //var identityContext = serviceScope.ServiceProvider.GetRequiredService<IIdentityServerInitializer>();
                //identityContext.SeedAsync().Wait();

                //var seedService = serviceScope.ServiceProvider.GetService<ISeedSerivce>();
                //seedService.InstallData(serviceProvider);
            }
        }
    }
}