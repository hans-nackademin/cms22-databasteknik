using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_CosmosDB.Contexts;
using WebApi_CosmosDB.Models;

namespace WebApi_CosmosDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateAsync(Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return new OkObjectResult(contact);
        }

    }
}
