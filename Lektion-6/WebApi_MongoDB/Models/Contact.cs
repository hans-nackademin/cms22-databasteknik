using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi_MongoDB.Models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public Address Address { get; set; } = null!;
    }
}
