using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WowAutoApp.Core.Domain.Emails;
using WowAutoApp.Services.Email;
using WowAutoApp.Services.Email.Smtp;

namespace wowautoapp.Extentions.StartupExtensions
{
    /// <summary>
    /// Dependency injection email configurator
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add dependency email config
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpOptions>(options =>
            {
                options.Host = configuration["Host"];
                options.Port = int.Parse(configuration["Port"]);
                options.UserName = configuration["EmailUserName"];
                options.Password = configuration["Password"];
                options.EnableSsl = bool.Parse(configuration["EnableSsl"]);
            });

            // Configure SystemEmailOptions
            services.Configure<EmailExtensionOptions>(options =>
            {
                options.BaseUrl = configuration["BaseUrl"];
                options.From = configuration["From"];
                //options.IconUrl = configuration["IconUrl"];
            });

            services.AddSingleton<IEmailService, SmtpEmailService>();
            services.AddTransient<IEmailExtensionService, EmailExtensionService>();
            services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
        }
    }
}