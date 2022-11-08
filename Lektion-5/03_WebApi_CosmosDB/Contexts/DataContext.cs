using _03_WebApi_CosmosDB.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_WebApi_CosmosDB.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToContainer("Products").HasPartitionKey(x => x.Id);
        }
    }
}
