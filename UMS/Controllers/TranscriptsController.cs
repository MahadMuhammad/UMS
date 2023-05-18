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
    public class TranscriptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TranscriptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transcripts
        public async Task<IActionResult> Index()
        {
              return _context.Transcripts != null ? 
                          View(await _context.Transcripts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Transcripts'  is null.");
        }

        // GET: Transcripts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Transcripts == null)
            {
                return NotFound();
            }

            var transcript = await _context.Transcripts
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (transcript == null)
            {
                return NotFound();
            }

            return View(transcript);
        }

        // GET: Transcripts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transcripts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNo,GradeLetter,GPA")] Transcript transcript)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transcript);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transcript);
        }

        // GET: Transcripts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Transcripts == null)
            {
                return NotFound();
            }

            var transcript = await _context.Transcripts.FindAsync(id);
            if (transcript == null)
            {
                return NotFound();
            }
            return View(transcript);
        }

        // POST: Transcripts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNo,GradeLetter,GPA")] Transcript transcript)
        {
            if (id != transcript.RollNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transcript);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranscriptExists(transcript.RollNo))
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
            return View(transcript);
        }

        // GET: Transcripts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Transcripts == null)
            {
                return NotFound();
            }

            var transcript = await _context.Transcripts
                .FirstOrDefaultAsync(m => m.RollNo == id);
            if (transcript == null)
            {
                return NotFound();
            }

            return View(transcript);
        }

        // POST: Transcripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Transcripts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transcripts'  is null.");
            }
            var transcript = await _context.Transcripts.FindAsync(id);
            if (transcript != null)
            {
                _context.Transcripts.Remove(transcript);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranscriptExists(string id)
        {
          return (_context.Transcripts?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
