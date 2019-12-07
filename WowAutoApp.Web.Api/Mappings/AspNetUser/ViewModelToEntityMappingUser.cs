using Castle.Core.Internal;
using wowautoapp.ViewModels.AspNetUser;
using WowAutoApp.Core.Domain;

namespace wowautoapp.Mappings.AspNetUser
{
    /// <summary>
    /// User view model to entity mapping
    /// </summary>
    public class ViewModelToEntityMappingUser : AutoMapper.Profile
    {
        /// <summary>
        /// User view model to entity mapping constructor
        /// </summary>
        public ViewModelToEntityMappingUser()
        {
            CreateMap<RegistrationViewModel, ApplicationUser>()
                .ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}