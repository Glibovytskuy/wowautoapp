using System;
using System.Collections.Generic;
using WowAutoApp.Core.Domain.Media;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain.Profile
{
    public class Profile : Entity, IEntity<int>
    {
        private ICollection<ProfilePicture> _profilePictures;

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string AvatarUrl { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string StreetAddress { get; set; }
        public int HouseFlatNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int MonthlyRent { get; set; }
        public string EmploymentStatus { get; set; }

        public virtual ICollection<ProfilePicture> ProfilePictures
        {
            get => _profilePictures ?? (_profilePictures = new List<ProfilePicture>());

            protected set => _profilePictures = value;
        }
    }
}