using System.Collections.Generic;
using System.Threading.Tasks;
using WowAutoApp.Core.Dto.ProfileDtos;

namespace WowAutoApp.Services.Profile
{
    public interface IProfileService : IGeneralService<Core.Domain.Profile.Profile>
    {
        void UpdateProfile(Core.Domain.Profile.Profile profile);
        void AddProfile(Core.Domain.Profile.Profile profile);
        Task<Core.Domain.Profile.Profile> GetProfileAsync(int id);
        string GetPictureUrlByProfileId(int profileId);
        Task<Core.Domain.Profile.Profile> GetProfileByUserIdAsync(string userId);
        Task<ProfileInfoDto> GetProfileInfoAsync(int profileId, int? workspaceId);
        string GetUserIdByProfileId(int profileId);
        List<string> GetUserIdsByProfileIds(List<int> profileIds);
    }
}