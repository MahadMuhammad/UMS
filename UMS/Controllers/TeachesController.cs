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
    public class TeachesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeachesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teaches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Teaches.Include(t => t.Course).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Teaches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Teaches == null)
            {
                return NotFound();
            }

            var teaches = await _context.Teaches
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherID == id);
            if (teaches == null)
            {
                return NotFound();
            }

            return View(teaches);
        }

        // GET: Teaches/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID");
            return View();
        }

        // POST: Teaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherID,CourseID")] Teaches teaches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", teaches.CourseID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", teaches.TeacherID);
            return View(teaches);
        }

        // GET: Teaches/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Teaches == null)
            {
                return NotFound();
            }

            var teaches = await _context.Teaches.FindAsync(id);
            if (teaches == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", teaches.CourseID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", teaches.TeacherID);
            return View(teaches);
        }

        // POST: Teaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TeacherID,CourseID")] Teaches teaches)
        {
            if (id != teaches.TeacherID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachesExists(teaches.TeacherID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", teaches.CourseID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", teaches.TeacherID);
            return View(teaches);
        }

        // GET: Teaches/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Teaches == null)
            {
                return NotFound();
            }

            var teaches = await _context.Teaches
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherID == id);
            if (teaches == null)
            {
                return NotFound();
            }

            return View(teaches);
        }

        // POST: Teaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Teaches == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Teaches'  is null.");
            }
            var teaches = await _context.Teaches.FindAsync(id);
            if (teaches != null)
            {
                _context.Teaches.Remove(teaches);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachesExists(string id)
        {
          return (_context.Teaches?.Any(e => e.TeacherID == id)).GetValueOrDefault();
        }
    }
}
