using System.Security.Claims;

namespace WowAutoApp.Services.Utilities
{
    public static partial class Extensions
    {
        public static string GetUserName(this ClaimsPrincipal identity)
        {
            var username = identity.FindFirst(ClaimTypes.NameIdentifier);

            return username?.Value;
        }
    }
}