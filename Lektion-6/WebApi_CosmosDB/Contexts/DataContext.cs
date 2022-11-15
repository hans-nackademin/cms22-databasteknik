using Microsoft.EntityFrameworkCore;
using WebApi_CosmosDB.Models;

namespace WebApi_CosmosDB.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToContainer("Contacts").HasPartitionKey(x => x.Id);
        }
    }
}
