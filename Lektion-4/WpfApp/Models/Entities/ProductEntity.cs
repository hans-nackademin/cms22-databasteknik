using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
