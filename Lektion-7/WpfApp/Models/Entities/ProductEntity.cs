using System;

namespace WpfApp.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Color { get; set; }

        public int CategoryId { get; set; }
        public ProductCategoryEntity Category { get; set; }
    }
}
