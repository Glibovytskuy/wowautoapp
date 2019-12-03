using System.Collections.Generic;
using WowAutoApp.Core.Domain.Media;
using WowAutoApp.Core.Enums;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Services.Media
{
    public interface IPictureService
    {
        /// <summary>
        /// Gets the default picture URL
        /// </summary>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <returns>Picture URL</returns>
        string GetDefaultPictureUrl(int targetSize = 0,
            PictureType defaultPictureType = PictureType.Entity,
            string storeLocation = null);

        /// <summary>
        /// Gets a picture
        /// </summary>
        /// <param name="pictureId">Picture identifier</param>
        /// <returns>Picture</returns>
        Picture GetPictureById(int pictureId);

        /// <summary>
        /// Gets a collection of pictures
        /// </summary>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Items on each page</param>
        /// <returns>Paged list of pictures</returns>
        IPagedList<Picture> GetPictures(int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets pictures by profile identifier
        /// </summary>
        /// <param name="profileId">Profile identifier</param>
        /// <param name="recordsToReturn">Number of records to return. 0 if you want to get all items</param>
        /// <returns>Pictures</returns>
        IList<Picture> GetPicturesByProfileId(int profileId, int recordsToReturn = 0);

        /// <summary>
        /// Gets pictures by identifiers
        /// </summary>
        /// <param name="ids">identifiers</param>
        /// <returns>Pictures</returns>
        IList<Picture> GetPicturesByIds(List<int> ids);

        /// <summary>
        /// Inserts a picture
        /// </summary>
        /// <param name="settings">The picture settings</param>
        /// <returns>Picture</returns>
        Picture InsertPicture(PictureSettings settings);

        /// <summary>
        /// Validates input picture dimensions
        /// </summary>
        /// <param name="pictureBinary">Picture binary</param>
        /// <param name="mimeType">MIME type</param>
        /// <returns>Picture binary or throws an exception</returns>
        byte[] ValidatePicture(byte[] pictureBinary, string mimeType);

        IDictionary<int, string> GetPicturesHash(int[] picturesIds);
    }
}
