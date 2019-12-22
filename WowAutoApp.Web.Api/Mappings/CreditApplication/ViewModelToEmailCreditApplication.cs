using wowautoapp.ViewModels.AspNetUser;
using WowAutoApp.Core.Dto.CreaditApplicationDtos;

namespace wowautoapp.Mappings.CreditApplication
{
    /// <summary>
    /// Profile view model to entity mapping
    /// </summary>
    public class ViewModelToEmailCreditApplication : AutoMapper.Profile
    {
        /// <summary>
        /// <see cref="ViewModelToEmailCreditApplication"/> constructor.
        /// </summary>
        public ViewModelToEmailCreditApplication()
        {
            CreateMap<RegistrationViewModel, CreditApplicationDto>();
        }
    }
}