using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WowAutoApp.Core.Interfaces;

namespace WowAutoApp.Core.Domain
{
    public class Address : Entity, IEntity<int>
    {
        public string StreetAddress { get; set; }
        public string StreetAddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        //public virtual ICollection<Buisness> Buisnesses { get; set; } = new List<Buisness>();
    }
}