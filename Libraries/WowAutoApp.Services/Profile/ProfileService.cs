using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using WowAutoApp.Core.Dto.ProfileDtos;
using WowAutoApp.Core.Repo;

namespace WowAutoApp.Services.Profile
{
    public class ProfileService : GeneralService<Core.Domain.Profile.Profile>, IProfileService
    {
        private const string ProfileByIdKey = "Netfully.profile.id-{0}";
        private const string ProfileByUserIdKey = "Netfully.profile.userId-{0}";
        private const int DefaultCacheTime = 60;

        #region Fields

        public ProfileService(
            IRepository<Core.Domain.Profile.Profile> profileRepository) 
            : base(profileRepository)
        {
        }

        #endregion

        public void AddProfile(Core.Domain.Profile.Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var key = string.Format(ProfileByIdKey, profile.Id);

            Repository.Insert(profile);
        }

        public string GetPictureUrlByProfileId(int profileId)
        {
            var profilePicture = Repository.TableNoTracking
                .Where(x => x.Id.Equals(profileId))
                .Select(x => x.ImageUrl)
                .FirstOrDefault();

            return profilePicture.IsNullOrEmpty() ? "" : profilePicture;
        }

        public virtual void UpdateProfile(Core.Domain.Profile.Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var key = string.Format(ProfileByIdKey, profile.Id);

            Repository.Update(profile);
        }

        /// <summary>
        /// Gets profile
        /// </summary>
        /// <param name="id">Profile identifier</param>
        /// <returns>Profile</returns>
        public async Task<Core.Domain.Profile.Profile> GetProfileAsync(int id)
        {
            return await Repository.Table
                .Include(m => m.ApplicationUser)
                .Include(m => m.ProfilePictures)
                .ThenInclude(m => m.Picture)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        /// <summary>
        /// Gets profile
        /// </summary>
        /// <param name="userId">Profile identifier</param>
        /// <returns>Profile</returns>
        public Core.Domain.Profile.Profile GetProfileByUserId(string userId)
        {
            if (userId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(userId));

            var key = string.Format(ProfileByUserIdKey, userId);

            return Repository.Table.FirstOrDefault(x => x.ApplicationUserId.Equals(userId));
        }

        /// <summary>
        /// Get Info about user profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public async Task<ProfileInfoDto> GetProfileInfoAsync(int profileId, int? workspaceId)
        {
            var infoModel = await TableNoTracking
                .Where(x => x.Id == profileId)
                .Select(x => new ProfileInfoDto()
                {
                    PhoneNumber = x.ApplicationUser.PhoneNumber,
                    Mail = x.ApplicationUser.Email
                }).FirstOrDefaultAsync();

            return infoModel;
        }

        /// <summary>
        /// Get Info about user profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public string GetUserIdByProfileId(int profileId)
        {
            var userId = Repository.Table
                .FirstOrDefault(x => x.Id.Equals(profileId))?.ApplicationUserId;

            return userId;
        }

        /// <summary>
        /// Get Info about user profile
        /// </summary>
        /// <param name="profileIds"></param>
        /// <returns></returns>
        public List<string> GetUserIdsByProfileIds(List<int> profileIds)
        {
            var userIds = Repository.Table
                .Where(x => profileIds.Contains(x.Id)).Select(u => u.ApplicationUserId).ToList();

            return userIds;
        }
    }
}