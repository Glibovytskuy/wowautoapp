using System.ComponentModel.DataAnnotations;
using wowautoapp.ViewModels.Abstract;

namespace wowautoapp.ViewModels.AspNetUser
{
    /// <summary>
    /// Forgot password view model
    /// </summary>
    public class ForgotPasswordViewModel : Callback
    {
        /// <summary>
        /// Email user
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}