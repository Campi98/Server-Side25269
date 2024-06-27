using dWeb2024.Data;
using dWeb2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dWeb2024.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FirstAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FirstAPI/users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/FirstAPI/users/5
        [HttpGet("users/{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/FirstAPI/users
        [HttpPost("users")]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id_do_User }, user);
        }

        // PUT: api/FirstAPI/users/5
        [HttpPut("users/{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.Id_do_User)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/FirstAPI/users/5
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id_do_User == id);
        }
    }
}
