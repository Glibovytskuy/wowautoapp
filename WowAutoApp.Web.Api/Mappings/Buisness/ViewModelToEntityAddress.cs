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
            CreateMap<BuisnessAddressViewModel, Address>();
        }
    }
}