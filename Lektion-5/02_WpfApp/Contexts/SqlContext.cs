using _02_WpfApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WpfApp.Contexts
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
