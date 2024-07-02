using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

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
            return await _context.Avaliacoes.Include(a => a.Avaliador).Include(a => a.Avaliado).ToListAsync();
        }

        // GET: api/Avaliacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.Include(a => a.Avaliador).Include(a => a.Avaliado).FirstOrDefaultAsync(a => a.ID_da_Avaliacao == id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }

        // POST: api/Avaliacoes
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao([FromBody] CreateAvaliacaoDto createAvaliacaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avaliacao = new Avaliacao
            {
                ID_do_Avaliador = createAvaliacaoDto.ID_do_Avaliador,
                ID_do_Avaliado = createAvaliacaoDto.ID_do_Avaliado,
                Classificacao = createAvaliacaoDto.Classificacao,
                Comentario = createAvaliacaoDto.Comentario,
                Data = createAvaliacaoDto.Data
            };

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvaliacao), new { id = avaliacao.ID_da_Avaliacao }, avaliacao);
        }

        // PUT: api/Avaliacoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao(int id, [FromBody] CreateAvaliacaoDto createAvaliacaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            avaliacao.ID_do_Avaliador = createAvaliacaoDto.ID_do_Avaliador;
            avaliacao.ID_do_Avaliado = createAvaliacaoDto.ID_do_Avaliado;
            avaliacao.Classificacao = createAvaliacaoDto.Classificacao;
            avaliacao.Comentario = createAvaliacaoDto.Comentario;
            avaliacao.Data = createAvaliacaoDto.Data;

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
            return _context.Avaliacoes.Any(e => e.ID_da_Avaliacao == id);
        }
    }
}
