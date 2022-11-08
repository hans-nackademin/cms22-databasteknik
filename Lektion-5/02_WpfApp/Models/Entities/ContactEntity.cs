using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WpfApp.Models.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public int ContactTypeId { get; set; }

        public virtual AddressEntity Address { get; set; }
        public virtual ContactTypeEntity ContactType { get; set; }
    }
}
