using System.ComponentModel.DataAnnotations;
using wowautoapp.ViewModels.Abstract;

namespace wowautoapp.ViewModels.AspNetUser
{
    /// <summary>
    /// Registration view model
    /// </summary>
    // TODO: Add Fluent Validations
    public class RegistrationViewModel : Callback
    {
        /// <summary>
        /// Email new user
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
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
        /// Avatar url user
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// Phone number user
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Security stamp when we invite user to workspace
        /// </summary>
        public string SecurityStamp { get; set; }
    }
}