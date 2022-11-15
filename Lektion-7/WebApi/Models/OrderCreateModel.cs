namespace WebApi.Models
{
    public class OrderCreateModel
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public List<ProductModel> Products { get; set; }
        
    }
}
