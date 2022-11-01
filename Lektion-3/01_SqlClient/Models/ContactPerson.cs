using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SqlClient.Models
{
    internal class ContactPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

    }
}
