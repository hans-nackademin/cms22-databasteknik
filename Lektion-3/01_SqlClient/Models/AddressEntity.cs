using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_SqlClient.Models
{
    internal class AddressEntity
    {

		public int Id { get; set; }

		private string streetName;
		public string StreetName
		{
			get { return streetName; }
			set { streetName = Regex.Replace(value, @"[\d-]", string.Empty).Trim(); }
		}

		private int streetNumber;
		public int StreetNumber
		{
			get { return streetNumber; }
			set { streetNumber = value; }
		}

		private string postalCode;
		public string PostalCode
		{
			get { return postalCode; }
			set { postalCode = value.Trim().Replace(" ", ""); }
		}

		private string city;
		public string City
		{
			get { return city; }
			set { city = value.Trim(); }
		}

	}
}
