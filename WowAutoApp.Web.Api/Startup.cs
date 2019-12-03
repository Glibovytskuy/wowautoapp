using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WowAutoApp.Data.Extensions;
using wowautoapp.Extensions.StartupExtensions.RuntimePipelineConfigurations;
using wowautoapp.Extensions.StartupExtensions;

namespace wowautoapp
{
    /// <summary>
    /// Startup project
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration startup project
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Inject project configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Database Context
            services.AddDatabase(Configuration);

            // Add swagger configuration
            services.AddSwaggerConfiguration();

            // Add Identity 
            services.AddIdentityConfiguration(Configuration);

            // Add mvc
            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="services"></param>
        public void Configure(IApplicationBuilder applicationBuilder,
            IHostingEnvironment hostingEnvironment,
            IServiceProvider services)
        {
            // Use swagger
            applicationBuilder.UseRuntimeSwaggerBuilder();

            if (hostingEnvironment.IsDevelopment())
                applicationBuilder.UseDeveloperExceptionPage();

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            applicationBuilder.SeedDatabase(services);
        }
    }
}