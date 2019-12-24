using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels
{
    public class VehicleViewModel
    {
        /// <summary>
        /// Vehicle Name
        /// </summary>
        public string VehicleName { get; set; }
        /// <summary>
        /// Down Payment user
        /// </summary>
        //[Required]
        public int DownPayment { get; set; }
        /// <summary>
        /// Total Amount user
        /// </summary>
        //[Required]
        public int TotalAmount { get; set; }
        /// <summary>
        /// Other Info user
        /// </summary>
        //[Required]
        public string OtherInfo { get; set; }
        /// <summary>
        /// Photo driver license
        /// </summary>
        //[Required]
        //public int DriverLicensePhotoId { get; set; }
    }
}