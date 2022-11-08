using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WpfApp.Models.Entities
{
    public class ContactTypeEntity
    {
        public int Id { get; set; }
        public string ContactType { get; set; } = null!;

        public ICollection<ContactEntity> Contacts { get; set; } = new List<ContactEntity>();
    }
}
