using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels.AspNetUser
{
    /// <summary>
    /// Change password view model
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Old password
        /// </summary>
        [Required]
        public string OldPassword { get; set; }
        /// <summary>
        /// New password
        /// </summary>
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
        /// <summary>
        /// Confirm password
        /// </summary>
        [Required]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
