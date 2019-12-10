using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Buisness : Entity, IEntity<int>
    {
        public string AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TaxIDNumber { get; set; }
        public string BusinessType { get; set; }
        public int Phone { get; set; }
        public int GrossAnnualIncome { get; set; }
        public int YearEstablished { get; set; }
    }
}