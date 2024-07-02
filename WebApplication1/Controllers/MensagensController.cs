using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

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

            return CreatedAtAction(nameof(GetMensagem), new { id = mensagem.ID_da_Mensagem }, mensagem);
        }

        // PUT: api/Mensagens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensagem(int id, [FromBody] Mensagem mensagem)
        {
            if (id != mensagem.ID_da_Mensagem)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingMensagem = await _context.Mensagens
                .Include(m => m.Remetente)
                .Include(m => m.Destinatario)
                .FirstOrDefaultAsync(m => m.ID_da_Mensagem == id);

            if (existingMensagem == null)
            {
                return NotFound();
            }

            // Update fields
            existingMensagem.ID_do_Remetente = mensagem.ID_do_Remetente;
            existingMensagem.ID_do_Destinatario = mensagem.ID_do_Destinatario;
            existingMensagem.Conteudo = mensagem.Conteudo;
            existingMensagem.Data_e_Hora = mensagem.Data_e_Hora;

            _context.Entry(existingMensagem).State = EntityState.Modified;

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
            return _context.Mensagens.Any(e => e.ID_da_Mensagem == id);
        }
    }
}
