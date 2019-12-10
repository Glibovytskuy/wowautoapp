using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels
{
    /// <summary>
    /// Buisness address
    /// </summary>
    public class BuisnessAddressViewModel
    {
        /// <summary>
        /// Street address
        /// </summary>
        [Required]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Street address line 2
        /// </summary>
        [Required]
        public string StreetAddressLine { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// State / Province
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Postal / Zip Code
        /// </summary>
        [Required]
        public string PostalCode { get; set; }
    }
}