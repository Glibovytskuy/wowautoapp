using System.Collections.Generic;

namespace WowAutoApp.Core.Domain.Media
{
    /// <summary>
    /// Represents a picture
    /// </summary>
    public class Picture : Entity
    {
        private ICollection<ProfilePicture> _profilePictures;
        /// <summary>
        /// Gets or sets the picture mime type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the "alt" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. profile name)
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// Gets or sets the "title" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. profile name)
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// Gets the profile pictures
        /// </summary>
        public virtual ICollection<ProfilePicture> ProfilePictures
        {
            get => _profilePictures ?? (_profilePictures = new List<ProfilePicture>());

            protected set => _profilePictures = value;
        }
    }
}