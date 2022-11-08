using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
