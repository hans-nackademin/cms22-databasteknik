using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
