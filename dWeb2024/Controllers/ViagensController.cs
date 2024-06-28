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
    public class ViagensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Viagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetViagens()
        {
            return await _context.Viagens.ToListAsync();
        }

        // GET: api/Viagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viagem>> GetViagem(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);

            if (viagem == null)
            {
                return NotFound();
            }

            return viagem;
        }

        // POST: api/Viagens
        [HttpPost]
        public async Task<ActionResult<Viagem>> PostViagem([FromBody] Viagem viagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Viagens.Add(viagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetViagem), new { id = viagem.Id_da_Viagem }, viagem);
        }

        // PUT: api/Viagens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViagem(int id, [FromBody] Viagem viagem)
        {
            if (id != viagem.Id_da_Viagem)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(viagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(id))
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

        // DELETE: api/Viagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViagem(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }

            _context.Viagens.Remove(viagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagens.Any(e => e.Id_da_Viagem == id);
        }
    }
}
