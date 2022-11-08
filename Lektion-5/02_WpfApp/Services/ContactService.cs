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

namespace _02_WpfApp.Services
{
    public class ContactService
    {
        private readonly SqlContext _context;

        public ContactService(SqlContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> CreateAsync(ContactRequest req)
        {
            try
            {
                var contactEntity = new ContactEntity
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Email = req.Email,
                    PhoneNumber = req.PhoneNumber
                };

                // check contactType
                var contactTypeEntity = await _context.ContactTypes.FirstOrDefaultAsync(x => x.ContactType == req.ContactType);
                if (contactTypeEntity != null)
                    contactEntity.ContactTypeId = contactTypeEntity.Id;
                else
                    contactEntity.ContactType = new ContactTypeEntity
                    {
                        ContactType = req.ContactType
                    };

                // check address
                var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == req.StreetName && x.PostalCode == req.PostalCode && x.City == req.City);
                if (addressEntity != null)
                    contactEntity.AddressId = addressEntity.Id;
                else
                    contactEntity.Address = new AddressEntity
                    {
                        StreetName = req.StreetName,
                        PostalCode = req.PostalCode,
                        City = req.City
                    };

                _context.Contacts.Add(contactEntity);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


    }
}
