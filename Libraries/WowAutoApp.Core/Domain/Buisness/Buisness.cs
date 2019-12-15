using System.ComponentModel.DataAnnotations.Schema;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Buisness : Entity, IEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int TaxIDNumber { get; set; }
        public string BusinessType { get; set; }
        public int Phone { get; set; }
        public int GrossAnnualIncome { get; set; }
        public int YearEstablished { get; set; }

        public int BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }

        //public int AddressId { get; set; }
        //[ForeignKey(nameof(AddressId))]
        //public virtual Address Address { get; set; }
    }
}