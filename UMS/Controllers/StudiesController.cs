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
    public class StudiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Studies.Include(s => s.Course).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Studies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Studies == null)
            {
                return NotFound();
            }

            var studies = await _context.Studies
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (studies == null)
            {
                return NotFound();
            }

            return View(studies);
        }

        // GET: Studies/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo");
            return View();
        }

        // POST: Studies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNo,CourseID,Time,Date,Status")] Studies studies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", studies.CourseID);
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", studies.RollNo);
            return View(studies);
        }

        // GET: Studies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Studies == null)
            {
                return NotFound();
            }

            var studies = await _context.Studies.FindAsync(id);
            if (studies == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", studies.CourseID);
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", studies.RollNo);
            return View(studies);
        }

        // POST: Studies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNo,CourseID,Time,Date,Status")] Studies studies)
        {
            if (id != studies.RollNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudiesExists(studies.RollNo))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", studies.CourseID);
            ViewData["RollNo"] = new SelectList(_context.Students, "RollNo", "RollNo", studies.RollNo);
            return View(studies);
        }

        // GET: Studies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Studies == null)
            {
                return NotFound();
            }

            var studies = await _context.Studies
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (studies == null)
            {
                return NotFound();
            }

            return View(studies);
        }

        // POST: Studies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Studies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Studies'  is null.");
            }
            var studies = await _context.Studies.FindAsync(id);
            if (studies != null)
            {
                _context.Studies.Remove(studies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudiesExists(string id)
        {
          return (_context.Studies?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
