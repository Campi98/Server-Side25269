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


        // GET: api/Viagens/5
        [HttpGet("name/{nome}")]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetViagemByDestino(string nome)
        {
            var viagem = _context.Viagens.Where(x => x.Destino == nome).ToList();

            if (viagem == null)
            {
                return NotFound();
            }

            return viagem;
        }

        // POST: api/Viagens
        [HttpPost]
        public async Task<ActionResult<Viagem>> PostViagem([FromBody] CreateViagemDto createViagemDto)
        {
            var viagem = new Viagem
            {
                Fotografia_relacionada_com_a_viagem = createViagemDto.Fotografia_relacionada_com_a_viagem,
                Destino = createViagemDto.Destino,
                Data_de_Inicio = createViagemDto.Data_de_Inicio,
                Data_de_Fim = createViagemDto.Data_de_Fim,
                Descricao = createViagemDto.Descricao,
                Itinerario = createViagemDto.Itinerario,
                Dicas_e_Recomendacoes = createViagemDto.Dicas_e_Recomendacoes,
                Rating_da_Viagem = createViagemDto.Rating_da_Viagem
            };

            _context.Viagens.Add(viagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetViagem), new { id = viagem.ID_da_Viagem }, viagem);
        }

        // PUT: api/Viagens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViagem(int id, [FromBody] CreateViagemDto createViagemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }

            viagem.Fotografia_relacionada_com_a_viagem = createViagemDto.Fotografia_relacionada_com_a_viagem;
            viagem.Destino = createViagemDto.Destino;
            viagem.Data_de_Inicio = createViagemDto.Data_de_Inicio;
            viagem.Data_de_Fim = createViagemDto.Data_de_Fim;
            viagem.Descricao = createViagemDto.Descricao;
            viagem.Itinerario = createViagemDto.Itinerario;
            viagem.Dicas_e_Recomendacoes = createViagemDto.Dicas_e_Recomendacoes;
            viagem.Rating_da_Viagem = createViagemDto.Rating_da_Viagem;

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
            return _context.Viagens.Any(e => e.ID_da_Viagem == id);
        }
    }
}
