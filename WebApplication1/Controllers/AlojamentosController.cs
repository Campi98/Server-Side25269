using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlojamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlojamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Alojamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alojamento>>> GetAlojamentos()
        {
            return await _context.Alojamentos.Include(a => a.Viagem).ToListAsync();
        }

        // GET: api/Alojamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alojamento>> GetAlojamento(int id)
        {
            var alojamento = await _context.Alojamentos.Include(a => a.Viagem).FirstOrDefaultAsync(a => a.ID_Alojamento == id);

            if (alojamento == null)
            {
                return NotFound();
            }

            return alojamento;
        }

        // POST: api/Alojamentos
        [HttpPost]
        public async Task<ActionResult<Alojamento>> PostAlojamento([FromBody] Alojamento alojamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Alojamentos.Add(alojamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlojamento), new { id = alojamento.ID_Alojamento }, alojamento);
        }

        // PUT: api/Alojamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlojamento(int id, [FromBody] Alojamento alojamento)
        {
            if (id != alojamento.ID_Alojamento)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlojamento = await _context.Alojamentos.FindAsync(id);
            if (existingAlojamento == null)
            {
                return NotFound();
            }

            existingAlojamento.Nome = alojamento.Nome;
            existingAlojamento.Localizacao = alojamento.Localizacao;
            existingAlojamento.Capacidade = alojamento.Capacidade;
            existingAlojamento.PrecoPorNoite = alojamento.PrecoPorNoite;
            existingAlojamento.Descricao = alojamento.Descricao;
            existingAlojamento.DataDisponivel = alojamento.DataDisponivel;
            existingAlojamento.Proprietario = alojamento.Proprietario;
            existingAlojamento.TelefoneProprietario = alojamento.TelefoneProprietario;
            existingAlojamento.ID_da_Viagem = alojamento.ID_da_Viagem;

            _context.Entry(existingAlojamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlojamentoExists(id))
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

        // DELETE: api/Alojamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlojamento(int id)
        {
            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento == null)
            {
                return NotFound();
            }

            _context.Alojamentos.Remove(alojamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlojamentoExists(int id)
        {
            return _context.Alojamentos.Any(e => e.ID_Alojamento == id);
        }
    }
}
