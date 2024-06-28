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
    public class MensagensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MensagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mensagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagens()
        {
            return await _context.Mensagens.ToListAsync();
        }

        // GET: api/Mensagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);

            if (mensagem == null)
            {
                return NotFound();
            }

            return mensagem;
        }

        // POST: api/Mensagens
        [HttpPost]
        public async Task<ActionResult<Mensagem>> PostMensagem([FromBody] Mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mensagens.Add(mensagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMensagem), new { id = mensagem.Id_da_Mensagem }, mensagem);
        }

        // PUT: api/Mensagens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensagem(int id, [FromBody] Mensagem mensagem)
        {
            if (id != mensagem.Id_da_Mensagem)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(mensagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(id))
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

        // DELETE: api/Mensagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            _context.Mensagens.Remove(mensagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagens.Any(e => e.Id_da_Mensagem == id);
        }
    }
}
