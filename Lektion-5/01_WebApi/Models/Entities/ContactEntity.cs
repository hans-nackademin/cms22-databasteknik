namespace _01_WebApi.Models.Entities
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

        public AddressEntity Address { get; set; } = new();
        public ContactTypeEntity ContactType { get; set; } = new();
    }
}
