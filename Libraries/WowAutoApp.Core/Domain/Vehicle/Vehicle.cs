using System.Collections.Generic;
using WowAutoApp.Core.Domain.Media;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Vehicle : Entity, IEntity<int>
    {
        public string OwnerLicenseId { get; set; }
        public virtual ApplicationUser OwnerLicense { get; set; }
        public int DownPayment { get; set; }
        public int TotalAmount { get; set; }
        public string OtherInfo { get; set; }
        public int DriverLicensePhotoId { get; set; }
        public virtual Picture DriverLicensePhoto { get; set; }
    }
}