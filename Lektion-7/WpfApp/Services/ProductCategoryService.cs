using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models;
using WpfApp.Models.Entities;

namespace WpfApp.Services
{
    public class ProductCategoryService
    {
        private readonly DataContext _context;

        public ProductCategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(ProductCategoryCreateModel model)
        {
            var productCategoryEntity = new ProductCategoryEntity
            {
                CategoryName = model.CategoryName
            };
            _context.Add(productCategoryEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ProductCategoryModel>> GetAll()
        {
            var productCategories = new List<ProductCategoryModel>();
            foreach (var category in await _context.ProductCategories.ToListAsync())
                productCategories.Add(new ProductCategoryModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });

            return productCategories;
        }
    }
}
