using ContactsReviews.Data;
using ContactsReviews.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly DataContext _context;

        public IncidentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Incident>> Get()
        {
            return Ok(await _context.Incidents.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Incident>> Create(InformationDto record)
        {


            if (!_context.Accounts.ToList().Exists(x => x.Name == record.AccountName))
            {
                return NotFound($"The account with name {record.AccountName} is not found!");
            }


            var existingAccount = _context.Accounts.ToList().Find(x => x.Name == record.AccountName);


            if (_context.Contacts.ToList().Exists(x => x.Email == record.ContactEmail))
            {
                var existingContact = _context.Contacts.ToList().Find(x => x.Email == record.ContactEmail);
                existingContact.Account = _context.Accounts.ToList().Find(x => x.Name == record.AccountName);
                existingContact.AccountId = existingContact.Account.Id;
            }
            else
            {
                var contact = new Contact();
                contact.FirstName = record.ContactFirstName;
                contact.LastName = record.ContactLastName;
                contact.Email = record.ContactEmail;
                contact.Account = existingAccount;
                contact.AccountId = existingAccount.Id;

                _context.Contacts.Add(contact);
            }

            var incident = new Incident();
            var incidentId = Guid.NewGuid();

            incident.Description = record.IncidentDescription;
            incident.IncidentId = incidentId;

            existingAccount.IncidentIdentifier = incidentId;

            _context.Incidents.Add(incident);

            await _context.SaveChangesAsync();
            return Ok(await _context.Incidents.ToListAsync());
        }


    }
}
