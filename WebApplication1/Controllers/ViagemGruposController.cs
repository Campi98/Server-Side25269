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

        // GET: ViagemGrupos/Details
        public async Task<IActionResult> Details(int? viagemId, int? grupoDeViagemId)
        {
            if (viagemId == null || grupoDeViagemId == null)
            {
                return NotFound();
            }

            var viagemGrupo = await _context.ViagemGrupos
                .Include(v => v.GrupoDeViagem)
                .Include(v => v.Viagem)
                .FirstOrDefaultAsync(m => m.ViagemId == viagemId && m.GrupoDeViagemId == grupoDeViagemId);
            if (viagemGrupo == null)
            {
                return NotFound();
            }

            return View(viagemGrupo);
        }

        // GET: ViagemGrupos/Create
        public IActionResult Create()
        {
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo");
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "Destino");
            return View();
        }

        // POST: ViagemGrupos/Create
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
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo", viagemGrupo.GrupoDeViagemId);
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "Destino", viagemGrupo.ViagemId);
            return View(viagemGrupo);
        }

        // GET: ViagemGrupos/Edit
        public async Task<IActionResult> Edit(int? viagemId, int? grupoDeViagemId)
        {
            if (viagemId == null || grupoDeViagemId == null)
            {
                return NotFound();
            }

            var viagemGrupo = await _context.ViagemGrupos
                .Include(vg => vg.Viagem)
                .Include(vg => vg.GrupoDeViagem)
                .FirstOrDefaultAsync(vg => vg.ViagemId == viagemId && vg.GrupoDeViagemId == grupoDeViagemId);
            if (viagemGrupo == null)
            {
                return NotFound();
            }
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo", viagemGrupo.GrupoDeViagemId);
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "Destino", viagemGrupo.ViagemId);
            return View(viagemGrupo);
        }

        // POST: ViagemGrupos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int viagemId, int grupoDeViagemId, [Bind("ViagemId,GrupoDeViagemId")] ViagemGrupo viagemGrupo)
        {
            if (viagemId != viagemGrupo.ViagemId || grupoDeViagemId != viagemGrupo.GrupoDeViagemId)
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
                    if (!ViagemGrupoExists(viagemGrupo.ViagemId, viagemGrupo.GrupoDeViagemId))
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
            ViewData["GrupoDeViagemId"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo", viagemGrupo.GrupoDeViagemId);
            ViewData["ViagemId"] = new SelectList(_context.Viagens, "ID_da_Viagem", "Destino", viagemGrupo.ViagemId);
            return View(viagemGrupo);
        }

        // GET: ViagemGrupos/Delete
        public async Task<IActionResult> Delete(int? viagemId, int? grupoDeViagemId)
        {
            if (viagemId == null || grupoDeViagemId == null)
            {
                return NotFound();
            }

            var viagemGrupo = await _context.ViagemGrupos
                .Include(v => v.GrupoDeViagem)
                .Include(v => v.Viagem)
                .FirstOrDefaultAsync(m => m.ViagemId == viagemId && m.GrupoDeViagemId == grupoDeViagemId);
            if (viagemGrupo == null)
            {
                return NotFound();
            }

            return View(viagemGrupo);
        }

        // POST: ViagemGrupos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int viagemId, int grupoDeViagemId)
        {
            var viagemGrupo = await _context.ViagemGrupos.FindAsync(viagemId, grupoDeViagemId);
            if (viagemGrupo != null)
            {
                _context.ViagemGrupos.Remove(viagemGrupo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemGrupoExists(int viagemId, int grupoDeViagemId)
        {
            return _context.ViagemGrupos.Any(e => e.ViagemId == viagemId && e.GrupoDeViagemId == grupoDeViagemId);
        }
    }
}
