using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class UsersMvcController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersMvcController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Include(u => u.Grupo).ToListAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Grupo)
                .FirstOrDefaultAsync(m => m.ID_do_User == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["ID_do_Grupo"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,Senha,Tipo,ID_do_Grupo")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_do_Grupo"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo", user.ID_do_Grupo);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["ID_do_Grupo"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo", user.ID_do_Grupo);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_do_User,Nome,Email,Senha,Tipo,ID_do_Grupo")] User user)
        {
            if (id != user.ID_do_User)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    var identityUser = await _userManager.FindByEmailAsync(user.Email);
                    var newClaim = new Claim("user-tipo", user.Tipo);
                    var oldClaim = (await _userManager.GetClaimsAsync(identityUser)).FirstOrDefault(x => x.Type == "user-tipo");
                    await _userManager.ReplaceClaimAsync(identityUser, oldClaim, newClaim);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID_do_User))
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
            ViewData["ID_do_Grupo"] = new SelectList(_context.GruposDeViagem, "ID_do_Grupo", "Nome_do_Grupo", user.ID_do_Grupo);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Grupo)
                .FirstOrDefaultAsync(m => m.ID_do_User == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID_do_User == id);
        }
    }
}
