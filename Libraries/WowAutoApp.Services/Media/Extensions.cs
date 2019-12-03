using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WowAutoApp.Core.Domain.Media;

namespace WowAutoApp.Services.Media
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Download binary array</returns>
        public static byte[] GetDownloadBits(this IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                fileStream.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }

        /// <summary>
        /// Gets the picture binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Picture binary array</returns>
        public static byte[] GetPictureBits(this IFormFile file)
        {
            return GetDownloadBits(file);
        }

        /// <summary>
        /// Get profile picture (for shopping cart and order details pages)
        /// </summary>
        /// <param name="profile">profile</param>
        /// <param name="attributesXml">Atributes (in XML format)</param>
        /// <param name="pictureService">Picture service</param>
        /// <returns>Picture</returns>
        public static Picture GetProfilePicture(this Core.Domain.Profile.Profile profile, string attributesXml,
            IPictureService pictureService)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            if (pictureService == null)
                throw new ArgumentNullException(nameof(pictureService));

            //now let's load the default profile picture
            var profilePicture = pictureService.GetPicturesByProfileId(profile.Id, 1).FirstOrDefault();
            if (profilePicture != null)
                return profilePicture;

            return null;
        }
    }
}