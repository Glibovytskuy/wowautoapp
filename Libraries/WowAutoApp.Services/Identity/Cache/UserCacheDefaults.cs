using System;
using System.Collections.Generic;
using System.Text;

namespace WowAutoApp.Services.Identity.Cache
{
    public static class UserCacheDefaults
    {
        /// <summary>
        /// Key for user detail model
        /// </summary>
        /// <remarks>
        /// {0} : user email
        /// </remarks>
        public static string GeneralPersonCacheKey => "WowAutoApp.public.user.userEmail-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string GeneralPersonPrefixCacheKey => "WowAutoApp.public.user";
        /// <summary>
        /// Key for user detail model
        /// </summary>
        /// <remarks>
        /// {0} : user email
        /// </remarks>
        public static string UserCacheKey => "WowAutoApp.user.userEmail-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string UserPrefixCacheKey => "WowAutoApp.user";
    }
}
