using System.Collections.Generic;
using WowAutoApp.Core.Domain.Media;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain.Profile
{
    public class Profile : Entity, IEntity<int>
    {
        private ICollection<ProfilePicture> _profilePictures;

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<ProfilePicture> ProfilePictures
        {
            get => _profilePictures ?? (_profilePictures = new List<ProfilePicture>());

            protected set => _profilePictures = value;
        }
    }
}