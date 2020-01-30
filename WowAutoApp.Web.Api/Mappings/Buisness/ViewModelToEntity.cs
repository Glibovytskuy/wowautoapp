using wowautoapp.ViewModels;
using WowAutoApp.Core.Domain;

namespace wowautoapp.Mappings.Buisness
{
    /// <summary>
    /// Address view model to entity mapping
    /// </summary>
    public class ViewModelToEntityAddress : AutoMapper.Profile
    {
        /// <summary>
        /// <see cref="ViewModelToEntityAddress"/> constructor.
        /// </summary>
        public ViewModelToEntityAddress()
        {
            CreateMap<RegistrationBuisnessViewModel, Address>()
                .ForMember(au => au.StreetAddress, map => map.MapFrom(vm => vm.BuisnessAddress.StreetAddress))
                .ForMember(au => au.StreetAddressLine, map => map.MapFrom(vm => vm.BuisnessAddress.StreetAddressLine))
                .ForMember(au => au.City, map => map.MapFrom(vm => vm.BuisnessAddress.City))
                .ForMember(au => au.State, map => map.MapFrom(vm => vm.BuisnessAddress.State))
                .ForMember(au => au.PostalCode, map => map.MapFrom(vm => vm.BuisnessAddress.PostalCode));

        }
    }

    /// <summary>
    /// Address view model to entity mapping
    /// </summary>
    public class ViewModelToEntityBuisness : AutoMapper.Profile
    {
        /// <summary>
        /// <see cref="ViewModelToEntityBuisness"/> constructor.
        /// </summary>
        public ViewModelToEntityBuisness()
        {
            //CreateMap<RegistrationBuisnessViewModel, WowAutoApp.Core.Domain.Buisness>()
            //    .ForMember(au => au.Address.City, map => map.MapFrom(vm => vm.BuisnessAddress.City))
            //    .ForMember(au => au.Address.PostalCode, map => map.MapFrom(vm => vm.BuisnessAddress.PostalCode))
            //    .ForMember(au => au.Address.State, map => map.MapFrom(vm => vm.BuisnessAddress.State))
            //    .ForMember(au => au.Address.StreetAddress, map => map.MapFrom(vm => vm.BuisnessAddress.StreetAddress))
            //    .ForMember(au => au.Address.StreetAddressLine, map => map.MapFrom(vm => vm.BuisnessAddress.StreetAddressLine));
        }
    }
}