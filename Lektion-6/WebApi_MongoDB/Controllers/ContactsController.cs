using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_MongoDB.Models;
using WebApi_MongoDB.Services;

namespace WebApi_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly NoSqlService _context;

        public ContactsController(NoSqlService context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            await _context.CreateAsync(contact);
            return new OkResult();
        }
    }
}
