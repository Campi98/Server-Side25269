using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new IdentityUser
            var identityUser = new IdentityUser
            {
                UserName = createUserDto.Email,
                Email = createUserDto.Email
            };

            // Create the user with the UserManager
            var result = await _userManager.CreateAsync(identityUser, createUserDto.Senha);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            // Create and save the application-specific user details
            var user = new User
            {
                Nome = createUserDto.Nome,
                Email = createUserDto.Email,
                Senha = createUserDto.Senha,
                Tipo = createUserDto.Tipo,
                ID_do_Grupo = createUserDto.ID_do_Grupo
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Create and save the perfil details
            var perfil = new Perfil
            {
                ID_do_User = user.ID_do_User,
                Fotografia_do_User = string.Empty,  // Initialize with empty or default values
                Interesses_de_Viagem = string.Empty,
                Destinos_Favoritos = string.Empty,
                Nivel_de_Experiencia_em_Viagens = string.Empty
            };

            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();


            var teste1 = await _userManager.FindByEmailAsync(createUserDto.Email);
            var claims = new List<Claim>
                    {
                        new Claim("user-tipo", createUserDto.Tipo)
                    };
            await _userManager.AddClaimsAsync(teste1, claims);

            return CreatedAtAction(nameof(GetUser), new { id = user.ID_do_User }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] User user)
        {
            if (id != user.ID_do_User)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.Users
                .Include(u => u.Perfil)
                .Include(u => u.Grupo)
                .FirstOrDefaultAsync(u => u.ID_do_User == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update fields
            existingUser.Nome = user.Nome;
            existingUser.Email = user.Email;
            existingUser.Senha = user.Senha;
            existingUser.Tipo = user.Tipo;
            existingUser.ID_do_Grupo = user.ID_do_Grupo;

            // Avoid null references for Perfil and Grupo
            if (user.Perfil != null)
            {
                existingUser.Perfil = user.Perfil;
            }

            if (user.Grupo != null)
            {
                existingUser.Grupo = user.Grupo;
            }

            _context.Entry(existingUser).State = EntityState.Modified;

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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Find the application-specific user
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Find the IdentityUser associated with the application user
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser == null)
            {
                return NotFound();
            }

            // Remove the IdentityUser
            var result = await _userManager.DeleteAsync(identityUser);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Remove the application-specific user
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID_do_User == id);
        }
    }
}