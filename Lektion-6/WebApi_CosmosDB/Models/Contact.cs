namespace WebApi_CosmosDB.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public Address Address { get; set; } = null!;
    }
}
