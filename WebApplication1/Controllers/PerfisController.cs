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
    public class PerfisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerfisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfis()
        {
            return await _context.Perfis.ToListAsync();
        }



        // GET: api/perfis/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfis.FirstOrDefaultAsync(p => p.ID_do_User == id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // POST: api/Perfis
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil([FromBody] CreatePerfilDto createPerfilDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = new Perfil
            {
                ID_do_User = createPerfilDto.ID_do_User,
                Fotografia_do_User = createPerfilDto.Fotografia_do_User,
                Interesses_de_Viagem = createPerfilDto.Interesses_de_Viagem,
                Destinos_Favoritos = createPerfilDto.Destinos_Favoritos,
                Nivel_de_Experiencia_em_Viagens = createPerfilDto.Nivel_de_Experiencia_em_Viagens
            };

            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerfil), new { id = perfil.ID_do_Perfil }, perfil);
        }

        // PUT: api/Perfis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, [FromBody] CreatePerfilDto createPerfilDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            perfil.Fotografia_do_User = createPerfilDto.Fotografia_do_User;
            perfil.Interesses_de_Viagem = createPerfilDto.Interesses_de_Viagem;
            perfil.Destinos_Favoritos = createPerfilDto.Destinos_Favoritos;
            perfil.Nivel_de_Experiencia_em_Viagens = createPerfilDto.Nivel_de_Experiencia_em_Viagens;

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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


        // DELETE: api/Perfis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfis.Any(e => e.ID_do_Perfil == id);
        }
    }
}