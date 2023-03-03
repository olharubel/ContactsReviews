using ContactsReviews.Data;
using ContactsReviews.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Account>> Get()
        {
            return Ok(await _context.Accounts.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Account>> Create(AccountDto accountDto)
        {
            if (_context.Accounts.ToList().Exists(x => x.Name == accountDto.Name))
            {
                return BadRequest("The account with same name already exists");
            }

            var account = new Account();
            account.Name = accountDto.Name;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return Ok(await _context.Accounts.ToListAsync());
        }
    }
}
