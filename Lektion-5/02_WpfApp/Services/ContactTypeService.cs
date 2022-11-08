using _02_WpfApp.Contexts;
using _02_WpfApp.Models;
using _02_WpfApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _02_WpfApp.Services
{
    public class ContactTypeService
    {
        private readonly SqlContext _context;

        public ContactTypeService(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactTypeModel>> GetAllAsync()
        {
            var contactTypes = new List<ContactTypeModel>();

            try
            {             
                foreach (var type in await _context.ContactTypes.ToListAsync())
                    contactTypes.Add(new ContactTypeModel
                    {
                        Id = type.Id,
                        ContactType = type.ContactType
                    });

                return contactTypes;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return contactTypes;
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var contactTypeEntity = await _context.ContactTypes.FindAsync(id);
                if (contactTypeEntity == null)
                    return new NotFoundResult();

                return new OkObjectResult(new ContactTypeModel
                {
                    Id = contactTypeEntity.Id,
                    ContactType = contactTypeEntity.ContactType,
                });
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        public async Task<ActionResult> UpdateAsync(int id, ContactTypeModel contactTypeModel)
        {
            try
            {
                if (id != contactTypeModel.Id)
                    return new BadRequestResult();

                var contactTypeEntity = await _context.ContactTypes.FindAsync(id);
                if (contactTypeEntity != null)
                {
                    contactTypeEntity.ContactType = contactTypeModel.ContactType;
                    _context.Entry(contactTypeEntity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new OkResult();
                }
                return new NotFoundResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        public async Task<ActionResult> CreateAsync(ContactTypeRequest req)
        {
            try
            {
                var contactTypeEntity = new ContactTypeEntity()
                {
                    ContactType = req.ContactType
                };

                _context.ContactTypes.Add(contactTypeEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(new ContactTypeModel
                {
                    Id = contactTypeEntity.Id,
                    ContactType = contactTypeEntity.ContactType
                });
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var contactTypeEntity = await _context.ContactTypes.FindAsync(id);
                if (contactTypeEntity == null)
                    return new NotFoundResult();

                _context.ContactTypes.Remove(contactTypeEntity);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
