using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class Grupo_de_ViagemMvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Grupo_de_ViagemMvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grupo_de_Viagem
        public async Task<IActionResult> Index()
        {
            var grupos = await _context.GruposDeViagem.ToListAsync();
            return View(grupos);
        }

        // GET: Grupo_de_Viagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.GruposDeViagem
                .FirstOrDefaultAsync(m => m.ID_do_Grupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupo_de_Viagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupo_de_Viagem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_do_Grupo,Nome_do_Grupo,Destino,Data_de_Inicio,Data_de_Fim,Descricao")] Grupo_de_Viagem grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupo);
        }

        // GET: Grupo_de_Viagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.GruposDeViagem.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            return View(grupo);
        }

        // POST: Grupo_de_Viagem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_do_Grupo,Nome_do_Grupo,Destino,Data_de_Inicio,Data_de_Fim,Descricao")] Grupo_de_Viagem grupo)
        {
            if (id != grupo.ID_do_Grupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Grupo_de_ViagemExists(grupo.ID_do_Grupo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(grupo);
        }

        // GET: Grupo_de_Viagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.GruposDeViagem
                .FirstOrDefaultAsync(m => m.ID_do_Grupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupo_de_Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.GruposDeViagem.FindAsync(id);
            _context.GruposDeViagem.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Grupo_de_ViagemExists(int id)
        {
            return _context.GruposDeViagem.Any(e => e.ID_do_Grupo == id);
        }
    }
}
