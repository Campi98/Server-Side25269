using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dWeb2024.Data;
using dWeb2024.Models;

namespace dWeb2024.Controllers
{
    public class Grupo_de_ViagemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Grupo_de_ViagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grupo_de_Viagem
        public async Task<IActionResult> Index()
        {
            return View(await _context.GruposDeViagem.ToListAsync());
        }

        // GET: Grupo_de_Viagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo_de_Viagem = await _context.GruposDeViagem
                .FirstOrDefaultAsync(m => m.Id_do_Grupo == id);
            if (grupo_de_Viagem == null)
            {
                return NotFound();
            }

            return View(grupo_de_Viagem);
        }

        // GET: Grupo_de_Viagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupo_de_Viagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_do_Grupo,AdminUser,Nome_do_Grupo,Destino,Data_de_Inicio,Data_de_Fim,Descricao")] Grupo_de_Viagem grupo_de_Viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo_de_Viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupo_de_Viagem);
        }

        // GET: Grupo_de_Viagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo_de_Viagem = await _context.GruposDeViagem.FindAsync(id);
            if (grupo_de_Viagem == null)
            {
                return NotFound();
            }
            return View(grupo_de_Viagem);
        }

        // POST: Grupo_de_Viagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_do_Grupo,AdminUser,Nome_do_Grupo,Destino,Data_de_Inicio,Data_de_Fim,Descricao")] Grupo_de_Viagem grupo_de_Viagem)
        {
            if (id != grupo_de_Viagem.Id_do_Grupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo_de_Viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Grupo_de_ViagemExists(grupo_de_Viagem.Id_do_Grupo))
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
            return View(grupo_de_Viagem);
        }

        // GET: Grupo_de_Viagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo_de_Viagem = await _context.GruposDeViagem
                .FirstOrDefaultAsync(m => m.Id_do_Grupo == id);
            if (grupo_de_Viagem == null)
            {
                return NotFound();
            }

            return View(grupo_de_Viagem);
        }

        // POST: Grupo_de_Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo_de_Viagem = await _context.GruposDeViagem.FindAsync(id);
            if (grupo_de_Viagem != null)
            {
                _context.GruposDeViagem.Remove(grupo_de_Viagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Grupo_de_ViagemExists(int id)
        {
            return _context.GruposDeViagem.Any(e => e.Id_do_Grupo == id);
        }
    }
}
