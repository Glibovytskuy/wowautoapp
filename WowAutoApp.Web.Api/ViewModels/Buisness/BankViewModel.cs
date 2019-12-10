using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels
{
    /// <summary>
    /// Name Bank
    /// </summary>
    public class BankViewModel
    {
        /// <summary>
        /// Name bank
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Phone bank
        /// </summary>
        [Required]
        public int Phone { get; set; }

        /// <summary>
        /// Branch Address
        /// </summary>
        [Required]
        public BuisnessAddressViewModel BranchAddress { get; set; }

        /// <summary>
        /// Contact Person
        /// </summary>
        [Required]
        public string ContactPerson { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        [Required]
        public int AccountNumber { get; set; }

        /// <summary>
        /// Representative 
        /// </summary>
        [Required]
        public string Representative { get; set; }
    }
}