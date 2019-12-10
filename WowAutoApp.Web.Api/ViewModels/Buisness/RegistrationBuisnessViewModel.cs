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
        /// Email new buisness
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Tax ID Number
        /// </summary>
        [Required]
        public int TaxIDNumber { get; set; }

        /// <summary>
        /// Business Type
        /// </summary>
        [Required]
        public string BusinessType { get; set; }

        /// <summary>
        /// Business Phone
        /// </summary>
        [Required]
        public int Phone { get; set; }

        /// <summary>
        /// Gross Annual Income
        /// </summary>
        [Required]
        public int GrossAnnualIncome { get; set; }

        /// <summary>
        /// Year Established
        /// </summary>
        [Required]
        public int YearEstablished { get; set; }

        /// <summary>
        /// Buisness address
        /// </summary>
        [Required]
        public BuisnessAddressViewModel BuisnessAddress { get; set; }

        /// <summary>
        /// Bank information
        /// </summary>
        [Required]
        public BankViewModel BankInformation { get; set; }
    }
}