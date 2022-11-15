namespace WebApi_MongoDB.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ContactCollectionName { get; set; } = null!;
    }
}
