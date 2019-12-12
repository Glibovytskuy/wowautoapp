using WowAutoApp.Core.Domain;
using wowautoapp.ViewModels.AspNetUser;

namespace wowautoapp.Mappings.Vehicles
{
    /// <summary>
    /// Vehicle view model to entity mapping
    /// </summary>
    public class ViewModelToEntityMappingVehicle : AutoMapper.Profile
    {
        /// <summary>
        /// <see cref="ViewModelToEntityMappingVehicle"/> constructor.
        /// </summary>
        public ViewModelToEntityMappingVehicle()
        {
            CreateMap<RegistrationViewModel, Vehicle>();
        }
    }
}