using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual Profile.Profile Profile { get; set; }
    }
}