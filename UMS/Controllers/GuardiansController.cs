using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMS.Data;
using UMS.Models;

namespace UMS.Controllers
{
    public class GuardiansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuardiansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guardians
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Guardians.Include(g => g.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Guardians/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Guardians == null)
            {
                return NotFound();
            }

            var guardian = await _context.Guardians
                .Include(g => g.Student)
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (guardian == null)
            {
                return NotFound();
            }

            return View(guardian);
        }

        // GET: Guardians/Create
        public IActionResult Create()
        {
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo");
            return View();
        }

        // POST: Guardians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNo,GuardianCNIC,FirstName,LastName,Relationship,Email,StudentRoll")] Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guardian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", guardian.RollNo);
            return View(guardian);
        }

        // GET: Guardians/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Guardians == null)
            {
                return NotFound();
            }

            var guardian = await _context.Guardians.FindAsync(id);
            if (guardian == null)
            {
                return NotFound();
            }
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", guardian.RollNo);
            return View(guardian);
        }

        // POST: Guardians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNo,GuardianCNIC,FirstName,LastName,Relationship,Email,StudentRoll")] Guardian guardian)
        {
            if (id != guardian.RollNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guardian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardianExists(guardian.RollNo))
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
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", guardian.RollNo);
            return View(guardian);
        }

        // GET: Guardians/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Guardians == null)
            {
                return NotFound();
            }

            var guardian = await _context.Guardians
                .Include(g => g.Student)
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (guardian == null)
            {
                return NotFound();
            }

            return View(guardian);
        }

        // POST: Guardians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Guardians == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Guardians'  is null.");
            }
            var guardian = await _context.Guardians.FindAsync(id);
            if (guardian != null)
            {
                _context.Guardians.Remove(guardian);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuardianExists(string id)
        {
          return (_context.Guardians?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
