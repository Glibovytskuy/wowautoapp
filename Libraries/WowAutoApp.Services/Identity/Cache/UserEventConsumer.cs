using WowAutoApp.Core.Domain;
using WowAutoApp.Core.Events;

namespace WowAutoApp.Services.Identity.Cache
{
    /// <inheritdoc cref="IConsumer{T}" />
    /// <summary>
    /// Represents a user event consumer with default cache mechanisms
    /// </summary>
    public class UserEventConsumer :
        IConsumer<EntityInsertedEvent<ApplicationUser>>,
        IConsumer<EntityUpdatedEvent<ApplicationUser>>,
        IConsumer<EntityDeletedEvent<ApplicationUser>>
    {

        public void HandleEvent(EntityInsertedEvent<ApplicationUser> eventMessage)
        {
            
        }

        public void HandleEvent(EntityUpdatedEvent<ApplicationUser> eventMessage)
        {
            
        }

        public void HandleEvent(EntityDeletedEvent<ApplicationUser> eventMessage)
        {
           
        }
    }
}
