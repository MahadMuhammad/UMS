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
    public class FinancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Finances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Finances.Include(f => f.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Finances/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Finances == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (finance == null)
            {
                return NotFound();
            }

            return View(finance);
        }

        // GET: Finances/Create
        public IActionResult Create()
        {
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo");
            return View();
        }

        // POST: Finances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNo,TotalFee,RemainingFee")] Finance finance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", finance.RollNo);
            return View(finance);
        }

        // GET: Finances/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Finances == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances.FindAsync(id);
            if (finance == null)
            {
                return NotFound();
            }
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", finance.RollNo);
            return View(finance);
        }

        // POST: Finances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNo,TotalFee,RemainingFee")] Finance finance)
        {
            if (id != finance.RollNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceExists(finance.RollNo))
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
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", finance.RollNo);
            return View(finance);
        }

        // GET: Finances/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Finances == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (finance == null)
            {
                return NotFound();
            }

            return View(finance);
        }

        // POST: Finances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Finances == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Finances'  is null.");
            }
            var finance = await _context.Finances.FindAsync(id);
            if (finance != null)
            {
                _context.Finances.Remove(finance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceExists(string id)
        {
          return (_context.Finances?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
