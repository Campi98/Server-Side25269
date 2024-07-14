using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace dWeb2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemGruposReactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViagemGruposReactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ViagemGrupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViagemGrupo>>> GetViagemGrupos()
        {
            return await _context.ViagemGrupos
                .Include(v => v.GrupoDeViagem)
                .Include(v => v.Viagem)
                .ToListAsync();
        }

        // GET: api/ViagemGrupos/{viagemId}/{grupoDeViagemId}
        [HttpGet("{viagemId}/{grupoDeViagemId}")]
        public async Task<ActionResult<ViagemGrupo>> GetViagemGrupo(int viagemId, int grupoDeViagemId)
        {
            var viagemGrupo = await _context.ViagemGrupos
                .Include(v => v.GrupoDeViagem)
                .Include(v => v.Viagem)
                .FirstOrDefaultAsync(m => m.ViagemId == viagemId && m.GrupoDeViagemId == grupoDeViagemId);

            if (viagemGrupo == null)
            {
                return NotFound();
            }

            return viagemGrupo;
        }

        // POST: api/ViagemGrupos
        [HttpPost]
        public async Task<ActionResult<ViagemGrupo>> PostViagemGrupo([FromBody] ViagemGrupo viagemGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ViagemGrupos.Add(viagemGrupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetViagemGrupo), new { viagemId = viagemGrupo.ViagemId, grupoDeViagemId = viagemGrupo.GrupoDeViagemId }, viagemGrupo);
        }

        // PUT: api/ViagemGrupos/{viagemId}/{grupoDeViagemId}
        [HttpPut("{viagemId}/{grupoDeViagemId}")]
        public async Task<IActionResult> PutViagemGrupo(int viagemId, int grupoDeViagemId, [FromBody] ViagemGrupo viagemGrupo)
        {
            if (viagemId != viagemGrupo.ViagemId || grupoDeViagemId != viagemGrupo.GrupoDeViagemId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(viagemGrupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemGrupoExists(viagemId, grupoDeViagemId))
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

        // DELETE: api/ViagemGrupos/{viagemId}/{grupoDeViagemId}
        [HttpDelete("{viagemId}/{grupoDeViagemId}")]
        public async Task<IActionResult> DeleteViagemGrupo(int viagemId, int grupoDeViagemId)
        {
            var viagemGrupo = await _context.ViagemGrupos.FindAsync(viagemId, grupoDeViagemId);
            if (viagemGrupo == null)
            {
                return NotFound();
            }

            _context.ViagemGrupos.Remove(viagemGrupo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViagemGrupoExists(int viagemId, int grupoDeViagemId)
        {
            return _context.ViagemGrupos.Any(e => e.ViagemId == viagemId && e.GrupoDeViagemId == grupoDeViagemId);
        }
    }
}
