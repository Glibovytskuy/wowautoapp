using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WowAutoApp.Core.Domain.Emails;
using WowAutoApp.Core.Dto.CreaditApplicationDtos;
using WowAutoApp.Services.Email.Token;

namespace WowAutoApp.Services.Email
{
    public class EmailExtensionService : IEmailExtensionService
    {
        private readonly IEmailService _emailService;
        private readonly EmailExtensionOptions _options;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        public EmailExtensionService(IEmailService emailService, IOptions<EmailExtensionOptions> options, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _emailService = emailService;
            _options = options.Value;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public async Task SendVerificationEmailAsync(EmailToken token, string baseUrl)
        {
            string email = token.Email;
            token.BaseUrl = baseUrl;

            //ToDo: Need to implement icon
            //token.IconUrl = _options.IconUrl;

            //ToDo: Need to implement options
            _options.From = "mr.otis.personal@gmail.com";

            var body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Email/EmailVerification.cshtml", token);
            await _emailService.SendAsync(body, "WowAutoApp (Verify Email)", _options.From, email);
        }

        public async Task SendCreditAplicationEmailAsync(CreditApplicationDto model)
        {
            //var body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Email/EmailCreditApplication.cshtml", model);

            //ToDo: Need to wrap razor page
 var test = "<div>  "+
 "      <h1>Please Check Credit Application account</h1>                                                          " +
 "      <table>                                                                                                   " +
 "          <tr><td><b> Personal Info </b></td></tr>                                                              " +
 "          <tr>                                                                                                  " +
 "              <td>First Name: </td>                                                                             " +
 $"              <td>{model.FirstName}</td>                                                                         " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Last Name: </td>                                                                              " +
 $"              <td>{model.LastName}</td>                                                                          " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Email: </td>                                                                                  " +
 $"              <td>{model.Email}</td>                                                                             " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Mobile Number: </td>                                                                          " +
 $"              <td>{model.MobileNumber}</td>                                                                      " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Phone Number: </td>                                                                           " +
 $"              <td>{model.PhoneNumber}</td>                                                                       " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr><td><b> Identification </b></td></tr>                                                             " +
 "          <tr>                                                                                                  " +
 "              <td>Date Of Birth: </td>                                                                          " +
 $"              <td>{model.DateOfBirth}</td>                                                                       " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Social Security Number: </td>                                                                 " +
 $"              <td>{model.SocialSecurityNumber}</td>                                                              " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr><td><b> Residence </b></td></tr>                                                                  " +
 "          <tr>                                                                                                  " +
 "              <td>Street Address: </td>                                                                         " +
 $"              <td>{model.StreetAddress}</td>                                                                     " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>House Flat Number: </td>                                                                      " +
 $"              <td>{model.HouseFlatNumber}</td>                                                                   " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>City: </td>                                                                                   " +
 $"              <td>{model.City}</td>                                                                              " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>State: </td>                                                                                  " +
 $"              <td>{model.State}</td>                                                                             " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Zip Code: </td>                                                                               " +
 $"              <td>{model.ZipCode}</td>                                                                           " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Monthly Rent: </td>                                                                           " +
 $"              <td>{model.MonthlyRent}</td>                                                                       " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Residence Owner: </td>                                                                        " +
 $"              <td>{model.ResidenceOwner}</td>                                                                    " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr><td><b> Employment Status </b></td></tr>                                                          " +
 "          <tr>                                                                                                  " +
 "              <td>Employment Status: </td>                                                                      " +
 $"              <td>{model.EmploymentStatus}</td>                                                                  " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr><td><b> Vehicle Interested In</b></td></tr>                                                       " +
 "          <tr>                                                                                                  " +
 "              <td>Vehicle Name: </td>                                                                           " +
 $"              <td>{model.VehicleName}</td>                                                                       " +
 "          </tr>                                                                                                 " +
 "          <tr>                                                                                                  " +
 "              <td>Down Payment: </td>                                                                           " +
 $"              <td>{model.DownPayment}</td>                                                                       " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Total Amount: </td>                                                                           " +
 $"              <td>{model.TotalAmount}</td>                                                                       " +
 "          </tr>                                                                                                 " +
 "                                                                                                                " +
 "          <tr>                                                                                                  " +
 "              <td>Other Info: </td>                                                                             " +
 $"              <td>{model.OtherInfo}</td>                                                                         " +
 "          </tr>                                                                                                 " +
 "      </table>                                                                                                  " +
 "  </div>                                                                                                        ";
            //
            await _emailService.SendAsync(test, "WowAutoApp (Verify Credit Application)", "mr.otis.personal@gmail.com", _options.From);
        }
    }
}