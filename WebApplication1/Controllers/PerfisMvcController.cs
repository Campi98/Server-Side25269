using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PerfisMvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerfisMvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Perfis
        public async Task<IActionResult> Index()
        {
            var perfis = await _context.Perfis.Include(p => p.User).ToListAsync();
            return View(perfis);
        }

        // GET: Perfis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfis
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID_do_Perfil == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfis/Create
        public IActionResult Create()
        {
            ViewData["ID_do_User"] = new SelectList(_context.Users, "ID_do_User", "Nome");
            return View();
        }

        // POST: Perfis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_do_User,Fotografia_do_User,Interesses_de_Viagem,Destinos_Favoritos,Nivel_de_Experiencia_em_Viagens")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_do_User"] = new SelectList(_context.Users, "ID_do_User", "Nome", perfil.ID_do_User);
            return View(perfil);
        }

        // GET: Perfis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            ViewData["ID_do_User"] = new SelectList(_context.Users, "ID_do_User", "Nome", perfil.ID_do_User);
            return View(perfil);
        }

        // POST: Perfis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_do_Perfil,ID_do_User,Fotografia_do_User,Interesses_de_Viagem,Destinos_Favoritos,Nivel_de_Experiencia_em_Viagens")] Perfil perfil)
        {
            if (id != perfil.ID_do_Perfil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.ID_do_Perfil))
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
            ViewData["ID_do_User"] = new SelectList(_context.Users, "ID_do_User", "Nome", perfil.ID_do_User);
            return View(perfil);
        }

        // GET: Perfis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfis
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID_do_Perfil == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // POST: Perfis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfis.Any(e => e.ID_do_Perfil == id);
        }
    }
}
