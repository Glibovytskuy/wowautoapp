using System;
using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels
{
    /// <summary>
    /// Registration buisness view model
    /// </summary>
    public class RegistrationBuisnessViewModel
    {
        /// <summary>
        /// Name new buisness
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Tax ID Number
        /// </summary>
        [Required]
        public int TaxIDNumber { get; set; }

        /// <summary>
        /// Year Established
        /// </summary>
        [Required]
        public int YearEstablished { get; set; }

        /// <summary>
        /// Business Type
        /// </summary>
        public string BusinessType { get; set; }

        /// <summary>
        /// Business Phone
        /// </summary>
        [Required]
        public int Phone { get; set; }

        /// <summary>
        /// Email new buisness
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Buisness address part
        /// </summary>
        [Required]
        public BuisnessAddressViewModel BuisnessAddress { get; set; }

        /// <summary>
        /// Mortgage/Rent monthly payment
        /// </summary>
        [Required]
        public string RentMonthlyPayment { get; set; }

        /// <summary>
        /// Years at address
        /// </summary>
        [Required]
        public int YearsAtAddress { get; set; }

        /// Personal information

        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Relationship to company
        /// </summary>
        [Required]
        public string RelationshipToCompany { get; set; }

        /// <summary>
        /// Social security number
        /// </summary>
        [Required]
        public int SocialSecurityNumber { get; set; }

        /// <summary>
        /// Primary phone number
        /// </summary>
        [Required]
        public int PrimaryPhoneNumber { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Street address
        /// </summary>
        [Required]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Street address line 2
        /// </summary>
        public string StreetAddressLine2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Postal zip code
        /// </summary>
        [Required]
        public string PostalZipCode { get; set; }

        /// <summary>
        /// Length of time at address
        /// </summary>
        [Required]
        public int LengthOfTimeAtAddress { get; set; }

        /// <summary>
        /// Occupancy type
        /// </summary>
        [Required]
        public string OccupancyType { get; set; }

        /// <summary>
        /// Mortgage/Rent monthly payment for personal information
        /// </summary>
        [Required]
        public string RentMonthlyPaymentPersonalInfo { get; set; }

        /// <summary>
        /// Annual Income
        /// </summary>
        [Required]
        public int AnnualIncome { get; set; }
    }
}