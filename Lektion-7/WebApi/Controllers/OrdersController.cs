using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost] 
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            var orderEntity = new OrderEntity
            {
                OrderDate = DateTime.Now,
                DueDate= DateTime.Now.AddDays(30),
                CustomerName = model.CustomerName,
                CustomerAddress = model.CustomerAddress
            };

            foreach (var product in model.Products)
                orderEntity.Products.Add(new ProductEntity { Id = product.Id });

            _context.Add(orderEntity);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
