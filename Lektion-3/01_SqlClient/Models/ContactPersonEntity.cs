using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SqlClient.Models
{
    internal class ContactPersonEntity
    {

        public int Id { get; set; }

        private string firstName;
        public string FirstName
        {
            get { return firstName;  }
            set { firstName = value.Trim(); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value.Trim(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value.Trim().ToLower(); }
        }

        private string phone;
        public string Phone { 
            get { return phone; } 
            set { phone = $"+46{value?.Replace(" ", "").Replace("-", "").Remove(0, 1)}"; } 
        }

        public int AddressId { get; set; }
    }
}
