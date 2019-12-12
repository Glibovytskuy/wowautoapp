using System.ComponentModel.DataAnnotations.Schema;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Bank : Entity, IEntity<int>
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string ContactPerson { get; set; }
        public int AccountNumber { get; set; }
        public string Representative { get; set; }
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
    }
}