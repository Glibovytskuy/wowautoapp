using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Address : Entity, IEntity<int>
    {
        public string BuisnessId { get; set; }
        public virtual Buisness Buisness { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}