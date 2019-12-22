using System.Threading.Tasks;
using WowAutoApp.Core.Dto.CreaditApplicationDtos;
using WowAutoApp.Services.Email.Token;

namespace WowAutoApp.Services.Email
{
    public interface IEmailExtensionService
    {
        Task SendVerificationEmailAsync(EmailToken token, string baseUrl);
        Task SendCreditAplicationEmailAsync(CreditApplicationDto token);
    }
}