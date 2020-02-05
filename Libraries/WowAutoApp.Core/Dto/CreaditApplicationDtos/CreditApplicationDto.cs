using System;
using WowAutoApp.Core.Domain.Enums;

namespace WowAutoApp.Core.Dto.CreaditApplicationDtos
{
    public class CreditApplicationDto
    {
        /// <summary>
        /// First name new user
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name new user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email new user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mobile number user
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Phone number user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Date Of Birth user
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Social Security Number user
        /// </summary>
        public string SocialSecurityNumber { get; set; }

        /// <summary>
        /// Street Address user
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// House/Flat Number* user
        /// </summary>
        public int HouseFlatNumber { get; set; }

        /// <summary>
        /// City user
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State user
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Zip code user
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Monthly Rent user
        /// </summary>
        public int MonthlyRent { get; set; }

        /// <summary>
        /// Residence Owner
        /// </summary>
        public OwnerType ResidenceOwner { get; set; }

        /// <summary>
        /// Employment Status user
        /// </summary>
        public EmploymentStatusType EmploymentStatus { get; set; }

        /// <summary>
        /// Vehicle Name
        /// </summary>
        public string VehicleName { get; set; }
        /// <summary>
        /// Down Payment user
        /// </summary>
        public int DownPayment { get; set; }
        /// <summary>
        /// Total Amount user
        /// </summary>
        public int TotalAmount { get; set; }
        /// <summary>
        /// Other Info user
        /// </summary>
        public string OtherInfo { get; set; }
        /// <summary>
        /// Photo driver license
        /// </summary>
        //public int DriverLicensePhotoId { get; set; }
    }
}