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
    public class ViagemGruposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViagemGruposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ViagemGrupos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ViagemGrupos.Include(v => v.GrupoDeViagem).Include(v => v.Viagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ViagemGrupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemGrupo = await _context.ViagemGrupos
                .Include(v => v.GrupoDeViagem)
                .Include(v => v.Viagem)
                .FirstOrDefaultAsync(m => m.ViagemId == id);
            if (viagemGrupo == null)
            {
                return NotFound();
            }

            return View(viagemGrupo);
        }

        // GET: ViagemGrupos/Create
        public IActionResult Create()
        {
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "ID_do_Grupo");
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "ID_da_Viagem");
            return View();
        }

        // POST: ViagemGrupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViagemId,GrupoDeViagemId")] ViagemGrupo viagemGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagemGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "ID_do_Grupo", viagemGrupo.GrupoDeViagemId);
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "ID_da_Viagem", viagemGrupo.ViagemId);
            return View(viagemGrupo);
        }

        // GET: ViagemGrupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemGrupo = await _context.ViagemGrupos.FindAsync(id);
            if (viagemGrupo == null)
            {
                return NotFound();
            }
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "ID_do_Grupo", viagemGrupo.GrupoDeViagemId);
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "ID_da_Viagem", viagemGrupo.ViagemId);
            return View(viagemGrupo);
        }

        // POST: ViagemGrupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViagemId,GrupoDeViagemId")] ViagemGrupo viagemGrupo)
        {
            if (id != viagemGrupo.ViagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagemGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemGrupoExists(viagemGrupo.ViagemId))
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
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "ID_do_Grupo", viagemGrupo.GrupoDeViagemId);
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "ID_da_Viagem", viagemGrupo.ViagemId);
            return View(viagemGrupo);
        }

        // GET: ViagemGrupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemGrupo = await _context.ViagemGrupos
                .Include(v => v.GrupoDeViagem)
                .Include(v => v.Viagem)
                .FirstOrDefaultAsync(m => m.ViagemId == id);
            if (viagemGrupo == null)
            {
                return NotFound();
            }

            return View(viagemGrupo);
        }

        // POST: ViagemGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagemGrupo = await _context.ViagemGrupos.FindAsync(id);
            if (viagemGrupo != null)
            {
                _context.ViagemGrupos.Remove(viagemGrupo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemGrupoExists(int id)
        {
            return _context.ViagemGrupos.Any(e => e.ViagemId == id);
        }
    }
}
