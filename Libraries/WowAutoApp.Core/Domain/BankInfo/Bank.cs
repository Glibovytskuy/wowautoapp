using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Bank : Entity, IEntity<int>
    {
        public string BuisnessId { get; set; }
        public virtual Buisness Buisness { get; set; }
        public string AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string ContactPerson { get; set; }
        public int AccountNumber { get; set; }
        public string Representative { get; set; }
    }
}