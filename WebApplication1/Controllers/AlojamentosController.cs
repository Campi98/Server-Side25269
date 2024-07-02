using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var alojamento = await _context.Alojamentos.Include(a => a.Viagem).FirstOrDefaultAsync(a => a.Id == id);

            if (alojamento == null)
            {
                return NotFound();
            }

            return alojamento;
        }

        // POST: api/Alojamentos
        [HttpPost]
        public async Task<ActionResult<Alojamento>> PostAlojamento([FromBody] CreateAlojamentoDto createAlojamentoDto)
        {
            var alojamento = new Alojamento
            {
                Nome = createAlojamentoDto.Nome,
                Localizacao = createAlojamentoDto.Localizacao,
                Capacidade = createAlojamentoDto.Capacidade,
                PrecoPorNoite = createAlojamentoDto.PrecoPorNoite,
                Descricao = createAlojamentoDto.Descricao,
                DataDisponivel = createAlojamentoDto.DataDisponivel,
                Proprietario = createAlojamentoDto.Proprietario,
                TelefoneProprietario = createAlojamentoDto.TelefoneProprietario,
                ID_da_Viagem = createAlojamentoDto.Id_da_Viagem
            };

            _context.Alojamentos.Add(alojamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlojamento), new { id = alojamento.Id }, alojamento);
        }

        // PUT: api/Alojamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlojamento(int id, [FromBody] CreateAlojamentoDto createAlojamentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento == null)
            {
                return NotFound();
            }

            alojamento.Nome = createAlojamentoDto.Nome;
            alojamento.Localizacao = createAlojamentoDto.Localizacao;
            alojamento.Capacidade = createAlojamentoDto.Capacidade;
            alojamento.PrecoPorNoite = createAlojamentoDto.PrecoPorNoite;
            alojamento.Descricao = createAlojamentoDto.Descricao;
            alojamento.DataDisponivel = createAlojamentoDto.DataDisponivel;
            alojamento.Proprietario = createAlojamentoDto.Proprietario;
            alojamento.TelefoneProprietario = createAlojamentoDto.TelefoneProprietario;
            alojamento.ID_da_Viagem = createAlojamentoDto.Id_da_Viagem;

            _context.Entry(alojamento).State = EntityState.Modified;

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
            return _context.Alojamentos.Any(e => e.Id == id);
        }
    }
}
