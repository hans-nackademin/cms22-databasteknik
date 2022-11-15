namespace WpfApp.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Color { get; set; }
        public int CategoryId { get; set; }
    }
}
