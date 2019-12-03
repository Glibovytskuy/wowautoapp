using WowAutoApp.Core.Domain;
using WowAutoApp.Core.Events;
using WowAutoApp.Services.Caching;

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
        private readonly IStaticCacheManager _cacheManager;
        public UserEventConsumer(IStaticCacheManager cacheManager) => _cacheManager = cacheManager;

        public void HandleEvent(EntityInsertedEvent<ApplicationUser> eventMessage)
        {
            _cacheManager.RemoveByPrefix(UserCacheDefaults.UserPrefixCacheKey);
            _cacheManager.RemoveByPrefix(UserCacheDefaults.GeneralPersonPrefixCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<ApplicationUser> eventMessage)
        {
            _cacheManager.RemoveByPrefix(UserCacheDefaults.UserPrefixCacheKey);
            _cacheManager.RemoveByPrefix(UserCacheDefaults.GeneralPersonPrefixCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<ApplicationUser> eventMessage)
        {
            _cacheManager.RemoveByPrefix(UserCacheDefaults.UserPrefixCacheKey);
            _cacheManager.RemoveByPrefix(UserCacheDefaults.GeneralPersonPrefixCacheKey);
        }
    }
}
