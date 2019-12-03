using Microsoft.Extensions.DependencyInjection;
using WowAutoApp.Core.Domain;
using WowAutoApp.Core.Events;
using WowAutoApp.Services.Identity.Cache;

namespace wowautoapp.Extensions.StartupExtensions
{
    /// <summary>
    /// Represents an event publisher configuration
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        /// Add event publisher configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddEventPublishConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IEventPublisher, EventPublisher>();

            services.AddSingleton<IConsumer<EntityInsertedEvent<ApplicationUser>>, UserEventConsumer>();
            services.AddSingleton<IConsumer<EntityDeletedEvent<ApplicationUser>>, UserEventConsumer>();
            services.AddSingleton<IConsumer<EntityUpdatedEvent<ApplicationUser>>, UserEventConsumer>();
        }
    }
}
