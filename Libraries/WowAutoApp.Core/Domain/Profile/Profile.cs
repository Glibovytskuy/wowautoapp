using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain.Profile
{
    public class Profile : Entity, IEntity<int>
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ImageUrl { get; set; }
    }
}