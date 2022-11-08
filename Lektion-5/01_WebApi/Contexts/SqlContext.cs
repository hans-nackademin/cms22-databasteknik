using _01_WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ContactTypeEntity> ContactTypes { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
    }
}
