using _01_SqlClient.Models;
using _01_SqlClient.Services;

var contactPerson = new ContactPerson();
var sqlService = new SqlService();

foreach (var contact in await sqlService.GetAllAsync())
    Console.WriteLine($"{contact.FirstName} {contact.LastName}. {contact.StreetName} {contact.StreetNumber}, {contact.PostalCode} {contact.City}");

Console.ReadLine();


Console.Write("First Name: ");
contactPerson.FirstName = Console.ReadLine();

Console.Write("Last Name: ");
contactPerson.LastName = Console.ReadLine();

Console.Write("Email: ");
contactPerson.Email = Console.ReadLine();

Console.Write("Phone: ");
contactPerson.Phone = Console.ReadLine();

Console.Write("Street Name: ");
contactPerson.StreetName = Console.ReadLine();

Console.Write("Street Number: ");
contactPerson.StreetNumber = int.Parse(Console.ReadLine());

Console.Write("Postal Code: ");
contactPerson.PostalCode = Console.ReadLine();

Console.Write("City: ");
contactPerson.City = Console.ReadLine();

await sqlService.CreateAsync(contactPerson);

