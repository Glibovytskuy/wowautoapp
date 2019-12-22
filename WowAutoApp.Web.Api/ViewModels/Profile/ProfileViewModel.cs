using System;
using System.ComponentModel.DataAnnotations;
using wowautoapp.ViewModels.Abstract;

namespace wowautoapp.ViewModels
{
    /// <summary>
    /// Profile view model
    /// </summary>
    public class ProfileViewModel : VehicleViewModel
    {
        /// <summary>
        /// First name new user
        /// </summary>
        //[Required]
        //[StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name new user
        /// </summary>
        //[Required]
        //[StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        /// <summary>
        /// Email new user
        /// </summary>
        //[Required]
        //[EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Is email verified
        /// </summary>
        public bool IsEmailVerified { get; set; }

        /// <summary>
        /// Mobile number user
        /// </summary>
        //[Required]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Phone number user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Date Of Birth user
        /// </summary>
        //[Required]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Social Security Number user
        /// </summary>
        //[Required]
        public int SocialSecurityNumber { get; set; }

        /// <summary>
        /// Street Address user
        /// </summary>
        //[Required]
        public string StreetAddress { get; set; }

        /// <summary>
        /// House/Flat Number* user
        /// </summary>
        //[Required]
        public int HouseFlatNumber { get; set; }

        /// <summary>
        /// City user
        /// </summary>
        //[Required]
        public string City { get; set; }

        /// <summary>
        /// State user
        /// </summary>
        //[Required]
        public string State { get; set; }

        /// <summary>
        /// Zip code user
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Monthly Rent user
        /// </summary>
        //[Required]
        public int MonthlyRent { get; set; }

        /// <summary>
        /// Residence Owner
        /// </summary>
        //[Required]
        public string ResidenceOwner { get; set; }

        /// <summary>
        /// Employment Status user
        /// </summary>
        //[Required]
        public string EmploymentStatus { get; set; }
    }

    /// <summary>
    /// Confirm Email token Model
    /// </summary>
    public class ConfirmEmailModel
    {
        /// <summary>
        /// Token
        /// </summary>
        [Required]
        public string Token { get; set; }
    }
}