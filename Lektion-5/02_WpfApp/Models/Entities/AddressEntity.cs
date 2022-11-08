using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WpfApp.Models.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public ICollection<ContactEntity> Contacts { get; set; } = new List<ContactEntity>();
    }
}
