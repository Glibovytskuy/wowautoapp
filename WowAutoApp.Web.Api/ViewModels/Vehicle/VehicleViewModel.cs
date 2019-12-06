using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wowautoapp.ViewModels
{
    public class VehicleViewModel
    {
        /// <summary>
        /// Vehicle Name user
        /// </summary>
        [Required]
        public string VehicleName { get; set; }
        /// <summary>
        /// Down Payment user
        /// </summary>
        [Required]
        public int DownPayment { get; set; }
        /// <summary>
        /// Total Amount user
        /// </summary>
        [Required]
        public int TotalAmount { get; set; }
        /// <summary>
        /// Other Info user
        /// </summary>
        [Required]
        public string OtherInfo { get; set; }
        /// <summary>
        /// Photo driver license
        /// </summary>
        [Required]
        public string DriverLicensePhoto { get; set; }
    }
}