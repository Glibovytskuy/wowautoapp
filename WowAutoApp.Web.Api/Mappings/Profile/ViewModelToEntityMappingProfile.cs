using wowautoapp.ViewModels.AspNetUser;

namespace wowautoapp.Mappings.Profile
{
    /// <summary>
    /// Profile view model to entity mapping
    /// </summary>
    public class ViewModelToEntityMappingProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Profile view model to entity mapping constructor
        /// </summary>
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, WowAutoApp.Core.Domain.Profile.Profile>();
        }
    }
}