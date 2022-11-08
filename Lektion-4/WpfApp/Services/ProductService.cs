using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Data;
using WpfApp.Models;
using WpfApp.Models.Entities;

namespace WpfApp.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ProductRequest req)
        {
            _context.Add(new ProductEntity
            {
                Name = req.Name,
                Description = req.Description,  
                Price = req.Price,
                CategoryId = req.CategoryId
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            foreach (var product in await _context.Products.Include(x => x.Category).ToListAsync())
                products.Add(new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryName = product.Category.Name
                });

            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category.Name
            };
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
