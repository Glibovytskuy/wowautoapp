using System;
using System.Collections.Generic;
using System.Linq;
using WowAutoApp.Core.Infrastructure;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Transforms;
using SixLabors.Primitives;
using WowAutoApp.Core.Repo;
using WowAutoApp.Core.Interfaces;
using WowAutoApp.Data.Interfaces;
using WowAutoApp.Core.Helpers;
using WowAutoApp.Core.Domain.Media;
using WowAutoApp.Core.Consts;
using WowAutoApp.Core.Enums;
using WowAutoApp.Services.Utilities;

namespace WowAutoApp.Services.Media
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<ProfilePicture> _profilePictureRepository;
        private readonly IRepository<Picture> _pictureRepository;
        private readonly MediaSettings _mediaSettings;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="profilePictureRepository">Profile picture repository</param>
        /// <param name="pictureRepository">Picture repository</param>
        /// <param name="settingService">Setting service</param>
        /// <param name="dbContext">Database context</param>
        /// <param name="mediaSettings">Media settings</param>
        /// <param name="fileProvider">File provider</param>
        public PictureService(
            IRepository<ProfilePicture> profilePictureRepository,
            IRepository<Picture> pictureRepository,
            IDbContext dbContext,
            MediaSettings mediaSettings)
        {
            _pictureRepository = pictureRepository;
            _profilePictureRepository = profilePictureRepository;
            _dbContext = dbContext;
            _mediaSettings = mediaSettings;
        }

        #region Utilities

        /// <summary>
        /// Returns the file extension from mime type.
        /// </summary>
        /// <param name="mimeType">Mime type</param>
        /// <returns>File extension</returns>
        protected virtual string GetFileExtensionFromMimeType(string mimeType)
        {
            if (mimeType == null)
                return null;

            var parts = mimeType.Split('/');
            var lastPart = parts[parts.Length - 1];
            switch (lastPart)
            {
                case "pjpeg":
                    lastPart = "jpg";
                    break;
                case "x-png":
                    lastPart = "png";
                    break;
                case "x-icon":
                    lastPart = "ico";
                    break;
            }
            return lastPart;
        }

        #endregion

        #region Getting picture local path/URL methods

        /// <summary>
        /// Gets the default picture URL
        /// </summary>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <returns>Picture URL</returns>
        public virtual string GetDefaultPictureUrl(int targetSize = 0,
            PictureType defaultPictureType = PictureType.Entity,
            string storeLocation = null)
        {
            string defaultImageFileName;
            switch (defaultPictureType)
            {
                case PictureType.Avatar:
                    defaultImageFileName = Consts.DefaultUserAvatar100Px;
                    break;
                default:
                    defaultImageFileName = Consts.DefaultUserAvatar100Px;
                    break;
            }

            return defaultImageFileName;
        }

        #endregion

        #region CRUD methods

        /// <summary>
        /// Gets a picture
        /// </summary>
        /// <param name="pictureId">Picture identifier</param>
        /// <returns>Picture</returns>
        public virtual Picture GetPictureById(int pictureId)
        {
            if (pictureId == 0)
                return null;

            return _pictureRepository.GetById(pictureId);
        }

        /// <summary>
        /// Gets a collection of pictures
        /// </summary>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Items on each page</param>
        /// <returns>Paged list of pictures</returns>
        public virtual IPagedList<Picture> GetPictures(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = from p in _pictureRepository.Table
                        orderby p.Id descending
                        select p;
            var pics = new PagedList<Picture>(query, pageIndex, pageSize);

            return pics;
        }

        /// <summary>
        /// Gets pictures by Profile identifier
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="recordsToReturn">Number of records to return. 0 if you want to get all items</param>
        /// <returns>Pictures</returns>
        public virtual IList<Picture> GetPicturesByProfileId(int profileId, int recordsToReturn = 0)
        {
            if (profileId == 0)
                return new List<Picture>();

            var query = from p in _pictureRepository.Table
                        join pp in _profilePictureRepository.Table on p.Id equals pp.PictureId
                        orderby pp.DisplayOrder, pp.Id
                        where pp.ProfileId == profileId
                        select p;

            if (recordsToReturn > 0)
                query = query.Take(recordsToReturn);

            var pics = query.ToList();

            return pics;
        }


        /// <summary>
        /// Gets pictures by identifiers
        /// </summary>
        /// <param name="ids">identifiers</param>
        /// <returns>Pictures</returns>
        public virtual IList<Picture> GetPicturesByIds(List<int> ids)
        {
            if (!ids.Any())
                return new List<Picture>();

            var query = _pictureRepository.TableNoTracking.Where(x => ids.Contains(x.Id));
            var pics = query.ToList();

            return pics;
        }

        /// <summary>
        /// Inserts a picture
        /// </summary>
        /// <param name="settings">The picture settings</param>
        /// <returns>Picture</returns>
        public virtual Picture InsertPicture(PictureSettings settings)
        {
            settings.MimeType = CommonHelper.EnsureNotNull(settings.MimeType);
            settings.MimeType = CommonHelper.EnsureMaximumLength(settings.MimeType, 20);

            var picture = new Picture
            {
                MimeType = settings.MimeType,
                AltAttribute = settings.AltAttribute,
                TitleAttribute = settings.TitleAttribute
            };
            _pictureRepository.Insert(picture);

            return picture;
        }
        /// <summary>
        /// Validates input picture dimensions
        /// </summary>
        /// <param name="pictureBinary">Picture binary</param>
        /// <param name="mimeType">MIME type</param>
        /// <returns>Picture binary or throws an exception</returns>
        public virtual byte[] ValidatePicture(byte[] pictureBinary, string mimeType)
        {
            try
            {
                //resize the image in accordance with the maximum size
                using (var image = Image.Load(pictureBinary, out var imageFormat))
                {
                    image.Mutate(imageProcess => imageProcess.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(_mediaSettings.MaximumImageSize = 1980)
                    }));

                    return ImageUtilities.EncodeImage(image, imageFormat, _mediaSettings);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get pictures hashes
        /// </summary>
        /// <param name="picturesIds">Pictures Ids</param>
        /// <returns></returns>
        public IDictionary<int, string> GetPicturesHash(int[] picturesIds)
        {
            var supportedLengthOfBinaryHash = Consts.SupportedLengthOfBinaryHash;
            if (supportedLengthOfBinaryHash == 0 || !picturesIds.Any())
                return new Dictionary<int, string>();

            const string strCommand = "SELECT [Id] as [PictureId], HASHBYTES('sha1', substring([PictureBinary], 0, {0})) as [Hash] FROM [Picture] where [Id] in ({1})";
            return _dbContext
                .QueryFromSql<PictureHashItem>(string.Format(strCommand, supportedLengthOfBinaryHash, picturesIds.Select(p => p.ToString()).Aggregate((all, current) => all + ", " + current))).Distinct()
                .ToDictionary(p => p.PictureId, p => BitConverter.ToString(p.Hash).Replace("-", ""));
        }

        #endregion
    }
}