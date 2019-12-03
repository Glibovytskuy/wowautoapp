namespace WowAutoApp.Core.Domain.Media
{
    /// <summary>
    /// Represents a picture
    /// </summary>
    public class ProfilePicture : Entity
    {
        /// <summary>
        /// Gets or sets the profile identifier
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets the picture
        /// </summary>
        public virtual Picture Picture { get; set; }

        /// <summary>
        /// Gets the profile
        /// </summary>
        public virtual Profile.Profile Profile { get; set; }
    }
}