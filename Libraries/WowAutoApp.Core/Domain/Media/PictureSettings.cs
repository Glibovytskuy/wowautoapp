namespace WowAutoApp.Core.Domain.Media
{
    public class PictureSettings
    {
        /// <summary>
        /// The picture binary
        /// </summary>
        public byte[] PictureBinary { get; set; }
        /// <summary>
        /// The picture MIME type
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// "alt" attribute for "img" HTML element
        /// </summary>
        public string AltAttribute { get; set; }
        /// <summary>
        /// "title" attribute for "img" HTML element
        /// </summary>
        public string TitleAttribute { get; set; }
        /// <summary>
        /// The picture security stamp
        /// </summary>
        public string SecurityStamp { get; set; }
    }
}