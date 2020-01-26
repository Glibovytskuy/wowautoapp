using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels.AspNetUser
{
    /// <summary>
    /// Registration view model
    /// </summary>
    public class ShortRegistrationViewModel
    {
        /// <summary>
        /// Password new user
        /// </summary>
        [Required]
        [MinLength(6, ErrorMessage = "The password must contain some symbol, upper case and lower case letters and numeric value.")]
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

        /// <summary>
        /// First name new user
        /// </summary>
        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name new user
        /// </summary>
        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        /// <summary>
        /// Email new user
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Is email verified
        /// </summary>
        public bool IsEmailVerified { get; set; }
    }
}