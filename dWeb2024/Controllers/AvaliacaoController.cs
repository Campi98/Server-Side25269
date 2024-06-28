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
    public class AvaliacoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvaliacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Avaliacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        // GET: api/Avaliacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }

        // POST: api/Avaliacoes
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao([FromBody] Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvaliacao), new { id = avaliacao.Id_da_Avaliacao }, avaliacao);
        }

        // PUT: api/Avaliacoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao(int id, [FromBody] Avaliacao avaliacao)
        {
            if (id != avaliacao.Id_da_Avaliacao)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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

        // DELETE: api/Avaliacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.Id_da_Avaliacao == id);
        }
    }
}
