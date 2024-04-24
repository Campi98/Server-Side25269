﻿using System;
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
    public class AvaliacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Avaliacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avaliacoes.ToListAsync());
        }

        // GET: Avaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes
                .FirstOrDefaultAsync(m => m.Id_da_Avaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_da_Avaliacao,Id_do_Avaliador,Id_do_Avaliado,Classificacao,Comentario,Data")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avaliacao);
        }

        // GET: Avaliacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_da_Avaliacao,Id_do_Avaliador,Id_do_Avaliado,Classificacao,Comentario,Data")] Avaliacao avaliacao)
        {
            if (id != avaliacao.Id_da_Avaliacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.Id_da_Avaliacao))
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
            return View(avaliacao);
        }

        // GET: Avaliacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes
                .FirstOrDefaultAsync(m => m.Id_da_Avaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.Id_da_Avaliacao == id);
        }
    }
}
