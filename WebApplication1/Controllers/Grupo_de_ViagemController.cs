using System;
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
    public class Grupo_de_ViagemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Grupo_de_ViagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Grupo_de_Viagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo_de_Viagem>>> GetGruposDeViagem()
        {
            return await _context.GruposDeViagem.ToListAsync();
        }

        // GET: api/Grupo_de_Viagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo_de_Viagem>> GetGrupoDeViagem(int id)
        {
            var grupo_de_Viagem = await _context.GruposDeViagem.FindAsync(id);

            if (grupo_de_Viagem == null)
            {
                return NotFound();
            }

            return grupo_de_Viagem;
        }

        // POST: api/Grupo_de_Viagem
        [HttpPost]
        public async Task<ActionResult<Grupo_de_Viagem>> PostGrupoDeViagem([FromBody] Grupo_de_Viagem grupo_de_Viagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GruposDeViagem.Add(grupo_de_Viagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupoDeViagem), new { id = grupo_de_Viagem.ID_do_Grupo }, grupo_de_Viagem);
        }

        // PUT: api/Grupo_de_Viagem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoDeViagem(int id, [FromBody] Grupo_de_Viagem grupo_de_Viagem)
        {
            if (id != grupo_de_Viagem.ID_do_Grupo)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGrupo = await _context.GruposDeViagem.FirstOrDefaultAsync(g => g.ID_do_Grupo == id);

            if (existingGrupo == null)
            {
                return NotFound();
            }

            // Update fields
            existingGrupo.Nome_do_Grupo = grupo_de_Viagem.Nome_do_Grupo;
            existingGrupo.Destino = grupo_de_Viagem.Destino;
            existingGrupo.Data_de_Inicio = grupo_de_Viagem.Data_de_Inicio;
            existingGrupo.Data_de_Fim = grupo_de_Viagem.Data_de_Fim;
            existingGrupo.Descricao = grupo_de_Viagem.Descricao;

            _context.Entry(existingGrupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Grupo_de_ViagemExists(id))
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

        // DELETE: api/Grupo_de_Viagem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoDeViagem(int id)
        {
            var grupo_de_Viagem = await _context.GruposDeViagem.FindAsync(id);
            if (grupo_de_Viagem == null)
            {
                return NotFound();
            }

            _context.GruposDeViagem.Remove(grupo_de_Viagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Grupo_de_ViagemExists(int id)
        {
            return _context.GruposDeViagem.Any(e => e.ID_do_Grupo == id);
        }
    }
}
