using _01_SqlClient.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace _01_SqlClient.Services
{
    internal class SqlService
    {
        public async Task<IEnumerable<ContactPerson>> GetAllAsync()
        {
            using var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HansMattin-Lassei\\Documents\\Utbildning\\CMS22\\cms22-databasteknik\\Lektion-3\\01_SqlClient\\local_sql_db.mdf;Integrated Security=True;Connect Timeout=30");
            var result = await conn.QueryAsync<ContactPerson>("SELECT cp.Id, cp.FirstName, cp.LastName, cp.Email, cp.Phone, a.StreetName, a.StreetNumber, a.PostalCode, a.City FROM ContactPersons cp JOIN Addresses a ON cp.AddressId = a.Id");
            return result;
        }


        public async Task CreateAsync(ContactPerson contactPerson)
        {
            using var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HansMattin-Lassei\\Documents\\Utbildning\\CMS22\\cms22-databasteknik\\Lektion-3\\01_SqlClient\\local_sql_db.mdf;Integrated Security=True;Connect Timeout=30");

            var contactPersonEntity = new ContactPersonEntity()
            {
                FirstName = contactPerson.FirstName,
                LastName = contactPerson.LastName,
                Email = contactPerson.Email,
                Phone = contactPerson.Phone
            };

            var addressEntity = new AddressEntity()
            {
                StreetName = contactPerson.StreetName,
                StreetNumber = contactPerson.StreetNumber,
                PostalCode = contactPerson.PostalCode,
                City = contactPerson.City
            };

            // kolla om en adress finns i databasen annars skapa adressen och ge tillbaka ett id
            contactPersonEntity.AddressId = await conn.QueryFirstOrDefaultAsync<int>("SELECT Id FROM Addresses WHERE StreetName = @StreetName AND StreetNumber = @StreetNumber AND PostalCode = @PostalCode AND City = @City", addressEntity);
            if (contactPersonEntity.AddressId == 0)
                contactPersonEntity.AddressId = await conn.ExecuteScalarAsync<int>("INSERT INTO Addresses OUTPUT INSERTED.Id VALUES (@StreetName, @StreetNumber, @PostalCode, @City)", contactPerson);

            await conn.ExecuteAsync("INSERT INTO ContactPersons VALUES (@FirstName, @LastName, @Email, @Phone, @AddressId)", contactPersonEntity);

        }
    }
}
