using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_WebApi.Contexts;
using _01_WebApi.Models.Entities;
using _01_WebApi.Models;

namespace _01_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly SqlContext _context;

        public ContactTypesController(SqlContext context)
        {
            _context = context;
        }



        // GET: api/ContactTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactTypeModel>>> GetContactTypes()
        {
            var contactTypes = new List<ContactTypeModel>();
            foreach (var type in await _context.ContactTypes.ToListAsync())
                contactTypes.Add(new ContactTypeModel
                {
                    Id = type.Id,
                    ContactType = type.ContactType
                });
                
                return contactTypes;
        }






        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactTypeModel>> GetContactTypeEntity(int id)
        {
            var contactTypeEntity = await _context.ContactTypes.FindAsync(id);

            if (contactTypeEntity == null)
            {
                return NotFound();
            }

            return new ContactTypeModel
            {
                Id = contactTypeEntity.Id,
                ContactType = contactTypeEntity.ContactType,
            };
        }

        // PUT: api/ContactTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactTypeEntity(int id, ContactTypeEntity contactTypeEntity)
        {
            if (id != contactTypeEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactTypeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTypeEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactTypeEntity>> PostContactTypeEntity(ContactTypeRequest req)
        {
            var contactTypeEntity = new ContactTypeEntity()
            {
                ContactType = req.ContactType
            };

            _context.ContactTypes.Add(contactTypeEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactTypeEntity", new { id = contactTypeEntity.Id }, contactTypeEntity);
        }

        // DELETE: api/ContactTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactTypeEntity(int id)
        {
            var contactTypeEntity = await _context.ContactTypes.FindAsync(id);
            if (contactTypeEntity == null)
            {
                return NotFound();
            }

            _context.ContactTypes.Remove(contactTypeEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactTypeEntityExists(int id)
        {
            return _context.ContactTypes.Any(e => e.Id == id);
        }
    }
}
