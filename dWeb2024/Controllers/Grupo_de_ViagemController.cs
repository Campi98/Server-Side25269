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
    public class GruposDeViagemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GruposDeViagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GruposDeViagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo_de_Viagem>>> GetGruposDeViagem()
        {
            return await _context.GruposDeViagem.ToListAsync();
        }

        // GET: api/GruposDeViagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo_de_Viagem>> GetGrupoDeViagem(int id)
        {
            var grupoDeViagem = await _context.GruposDeViagem.FindAsync(id);

            if (grupoDeViagem == null)
            {
                return NotFound();
            }

            return grupoDeViagem;
        }

        // POST: api/GruposDeViagem
        [HttpPost]
        public async Task<ActionResult<Grupo_de_Viagem>> PostGrupoDeViagem([FromBody] Grupo_de_Viagem grupoDeViagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GruposDeViagem.Add(grupoDeViagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupoDeViagem), new { id = grupoDeViagem.Id_do_Grupo }, grupoDeViagem);
        }

        // PUT: api/GruposDeViagem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoDeViagem(int id, [FromBody] Grupo_de_Viagem grupoDeViagem)
        {
            if (id != grupoDeViagem.Id_do_Grupo)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(grupoDeViagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoDeViagemExists(id))
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

        // DELETE: api/GruposDeViagem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoDeViagem(int id)
        {
            var grupoDeViagem = await _context.GruposDeViagem.FindAsync(id);
            if (grupoDeViagem == null)
            {
                return NotFound();
            }

            _context.GruposDeViagem.Remove(grupoDeViagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoDeViagemExists(int id)
        {
            return _context.GruposDeViagem.Any(e => e.Id_do_Grupo == id);
        }
    }
}
