using dWeb2024.Data;
using dWeb2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dWeb2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("saveImagem")]
        public async Task<IActionResult> SaveImagem([FromBody] ImagemDto imagemDto)
        {
            if (imagemDto == null || string.IsNullOrEmpty(imagemDto.Imagem))
            {
                return BadRequest("Imagem inválida.");
            }

            var imagem = new Imagem { Base64String = imagemDto.Imagem };
            _context.Imagens.Add(imagem);
            await _context.SaveChangesAsync();

            return Ok("Imagem guardada com sucesso.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagem>>> GetImagens()
        {
            return await _context.Imagens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Imagem>> GetImagem(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);

            if (imagem == null)
            {
                return NotFound();
            }

            return imagem;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagem(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }

            _context.Imagens.Remove(imagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}