using dWeb2024.Data;
using dWeb2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dWeb2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerfisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfis()
        {
            return await _context.Perfis.ToListAsync();
        }

        // GET: api/Perfis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // POST: api/Perfis
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil([FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerfil), new { id = perfil.Id_do_Perfil }, perfil);
        }

        // PUT: api/Perfis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, [FromBody] Perfil perfil)
        {
            if (id != perfil.Id_do_Perfil)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // DELETE: api/Perfis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfis.Any(e => e.Id_do_Perfil == id);
        }
    }
}
