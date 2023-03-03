using ContactsReviews.Data;
using ContactsReviews.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactsReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Contact>> Get()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Create(ContactDto contactDto)
        {
            if (_context.Contacts.ToList().Exists(x => x.Email == contactDto.Email))
            {
                return BadRequest("The contact with same email already exists");
            }

            var contact = new Contact();
            contact.FirstName = contactDto.FirstName;
            contact.LastName = contactDto.LastName;
            contact.Email = contactDto.Email;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }
    }
}
