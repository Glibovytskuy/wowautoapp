using System.Collections.Generic;

namespace WowAutoApp.Core.Domain.Media
{
    public class Picture : Entity
    {
        public string MimeType { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }

        public virtual ICollection<ProfilePicture> ProfilePictures { get; set; } = new List<ProfilePicture>();
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}