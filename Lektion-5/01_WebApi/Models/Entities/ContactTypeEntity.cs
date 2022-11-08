namespace _01_WebApi.Models.Entities
{
    public class ContactTypeEntity
    {
        public int Id { get; set; }
        public string ContactType { get; set; } = null!;

        public ICollection<ContactEntity> Contacts { get; set; } = new List<ContactEntity>();
    }
}
