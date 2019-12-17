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
    /// Bank view model to entity mapping
    /// </summary>
    public class ViewModelToEntityBank : AutoMapper.Profile
    {
        /// <summary>
        /// <see cref="ViewModelToEntityBank"/> constructor.
        /// </summary>
        public ViewModelToEntityBank()
        {
            CreateMap<RegistrationBuisnessViewModel, Bank>()
                .ForMember(au => au.AccountNumber, map => map.MapFrom(vm => vm.BankInformation.AccountNumber))
                .ForMember(au => au.ContactPerson, map => map.MapFrom(vm => vm.BankInformation.ContactPerson))
                .ForMember(au => au.Name, map => map.MapFrom(vm => vm.BankInformation.Name))
                .ForMember(au => au.Phone, map => map.MapFrom(vm => vm.BankInformation.Phone))
                .ForMember(au => au.Representative, map => map.MapFrom(vm => vm.BankInformation.Representative));
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
            CreateMap<RegistrationBuisnessViewModel, WowAutoApp.Core.Domain.Buisness>()
                .ForMember(au => au.StreetAddress, map => map.MapFrom(vm => vm.BuisnessAddress.StreetAddress))
                .ForMember(au => au.StreetAddressLine, map => map.MapFrom(vm => vm.BuisnessAddress.StreetAddressLine))
                .ForMember(au => au.City, map => map.MapFrom(vm => vm.BuisnessAddress.City))
                .ForMember(au => au.State, map => map.MapFrom(vm => vm.BuisnessAddress.State))
                .ForMember(au => au.PostalCode, map => map.MapFrom(vm => vm.BuisnessAddress.PostalCode));
        }
    }
}