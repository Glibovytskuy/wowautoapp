using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels.AspNetUser
{
    /// <summary>
    /// Registration view model
    /// </summary>
    public class RegistrationViewModel : ProfileViewModel
    {
        /// <summary>
        /// Password new user
        /// </summary>
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        /// <summary>
        /// Confirm password new user
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Security stamp when we invite user to workspace
        /// </summary>
        public string SecurityStamp { get; set; }
        /// <summary>
        /// Callback Url of client that calls api
        /// </summary>
        [Required]
        public string CallbackUrl { get; set; }
    }
}