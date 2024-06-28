using dWeb2024.Data;
using dWeb2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dWeb2024.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FirstAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FirstAPI/users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/FirstAPI/users/5
        [HttpGet("users/{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/FirstAPI/users
        [HttpPost("users")]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id_do_User }, user);
        }

        // PUT: api/FirstAPI/users/5
        [HttpPut("users/{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.Id_do_User)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/FirstAPI/users/5
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id_do_User == id);
        }

        // Método auxiliar para validar o modelo
        private void ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(string.Join("; ", errors));
            }
        }

        // ############################################################################################################

        // GET: api/FirstAPI/perfis
        [HttpGet("perfis")]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfis()
        {
            return await _context.Perfis.ToListAsync();
        }

        // GET: api/FirstAPI/perfis/5
        [HttpGet("perfis/{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // POST: api/FirstAPI/perfis
        [HttpPost("perfis")]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.Id_do_Perfil }, perfil);
        }

        // PUT: api/FirstAPI/perfis/5
        [HttpPut("perfis/{id}")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.Id_do_Perfil)
            {
                return BadRequest();
            }

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

        // DELETE: api/FirstAPI/perfis/5
        [HttpDelete("perfis/{id}")]
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
            return _context.Perfis.Any(e => e.Id_do_Perfil == id);
        }


        // ############################################################################################################

        // GET: api/FirstAPI/avaliacoes
        [HttpGet("avaliacoes")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        // GET: api/FirstAPI/avaliacoes/5
        [HttpGet("avaliacoes/{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }

        // POST: api/FirstAPI/avaliacoes
        [HttpPost("avaliacoes")]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacao", new { id = avaliacao.Id_da_Avaliacao }, avaliacao);
        }

        // PUT: api/FirstAPI/avaliacoes/5
        [HttpPut("avaliacoes/{id}")]
        public async Task<IActionResult> PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id_da_Avaliacao)
            {
                return BadRequest();
            }

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

        // DELETE: api/FirstAPI/avaliacoes/5
        [HttpDelete("avaliacoes/{id}")]
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
            return _context.Avaliacoes.Any(e => e.Id_da_Avaliacao == id);
        }


        // ############################################################################################################

        // GET: api/FirstAPI/grupos_de_viagem
        [HttpGet("grupos_de_viagem")]
        public async Task<ActionResult<IEnumerable<Grupo_de_Viagem>>> GetGruposDeViagem()
        {
            return await _context.GruposDeViagem.ToListAsync();
        }

        // GET: api/FirstAPI/grupos_de_viagem/5
        [HttpGet("grupos_de_viagem/{id}")]
        public async Task<ActionResult<Grupo_de_Viagem>> GetGrupoDeViagem(int id)
        {
            var grupoDeViagem = await _context.GruposDeViagem.FindAsync(id);

            if (grupoDeViagem == null)
            {
                return NotFound();
            }

            return grupoDeViagem;
        }

        // POST: api/FirstAPI/grupos_de_viagem
        [HttpPost("grupos_de_viagem")]
        public async Task<ActionResult<Grupo_de_Viagem>> PostGrupoDeViagem(Grupo_de_Viagem grupoDeViagem)
        {
            _context.GruposDeViagem.Add(grupoDeViagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoDeViagem", new { id = grupoDeViagem.Id_do_Grupo }, grupoDeViagem);
        }

        // PUT: api/FirstAPI/grupos_de_viagem/5
        [HttpPut("grupos_de_viagem/{id}")]
        public async Task<IActionResult> PutGrupoDeViagem(int id, Grupo_de_Viagem grupoDeViagem)
        {
            if (id != grupoDeViagem.Id_do_Grupo)
            {
                return BadRequest();
            }

            _context.Entry(grupoDeViagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoDeViagemExists(id))
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

        // DELETE: api/FirstAPI/grupos_de_viagem/5
        [HttpDelete("grupos_de_viagem/{id}")]
        public async Task<IActionResult> DeleteGrupoDeViagem(int id)
        {
            var grupoDeViagem = await _context.GruposDeViagem.FindAsync(id);
            if (grupoDeViagem == null)
            {
                return NotFound();
            }

            _context.GruposDeViagem.Remove(grupoDeViagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoDeViagemExists(int id)
        {
            return _context.GruposDeViagem.Any(e => e.Id_do_Grupo == id);
        }


        // ############################################################################################################

        // GET: api/FirstAPI/mensagens
        [HttpGet("mensagens")]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagens()
        {
            return await _context.Mensagens.ToListAsync();
        }

        // GET: api/FirstAPI/mensagens/5
        [HttpGet("mensagens/{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);

            if (mensagem == null)
            {
                return NotFound();
            }

            return mensagem;
        }

        // POST: api/FirstAPI/mensagens
        [HttpPost("mensagens")]
        public async Task<ActionResult<Mensagem>> PostMensagem(Mensagem mensagem)
        {
            _context.Mensagens.Add(mensagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMensagem", new { id = mensagem.Id_da_Mensagem }, mensagem);
        }

        // PUT: api/FirstAPI/mensagens/5
        [HttpPut("mensagens/{id}")]
        public async Task<IActionResult> PutMensagem(int id, Mensagem mensagem)
        {
            if (id != mensagem.Id_da_Mensagem)
            {
                return BadRequest();
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

        // DELETE: api/FirstAPI/mensagens/5
        [HttpDelete("mensagens/{id}")]
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
