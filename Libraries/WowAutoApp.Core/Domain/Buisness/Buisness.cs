using System;
using System.ComponentModel.DataAnnotations.Schema;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Buisness : Entity, IEntity<int>
    {
        public string Name { get; set; }
        public int TaxIDNumber { get; set; }
        public int YearEstablished { get; set; }
        public string BusinessType { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string RentMonthlyPayment { get; set; }
        public int YearsAtAddress { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RelationshipToCompany { get; set; }
        public int SocialSecurityNumber { get; set; }
        public int PrimaryPhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int LengthOfTimeAtAddress { get; set; }
        public string OccupancyType { get; set; }
        public string RentMonthlyPaymentPersonalInfo { get; set; }
        public int AnnualIncome { get; set; }

        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
    }
}