using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISTPLab.Models;

namespace ISTPLab.Controllers
{
    public class AuditoriesController : Controller
    {
        private readonly TimeTableContext _context;

        public AuditoriesController(TimeTableContext context)
        {
            _context = context;
        }

        // GET: Auditories
        public async Task<IActionResult> Index()
        {
            var timeTableContext = _context.Auditories.Include(a => a.FacultyNavigation);
            return View(await timeTableContext.ToListAsync());
        }

        // GET: Auditories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auditories == null)
            {
                return NotFound();
            }

            var auditory = await _context.Auditories
                .Include(a => a.FacultyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auditory == null)
            {
                return NotFound();
            }

            return View(auditory);
        }

        // GET: Auditories/Create
        public IActionResult Create()
        {
            ViewData["Faculty"] = new SelectList(_context.Faculties, "Id", "Name");
            return View();
        }

        // POST: Auditories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Floor,Number,Faculty")] Auditory auditory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Faculty"] = new SelectList(_context.Faculties, "Id", "Name", auditory.Faculty);
            return View(auditory);
        }

        // GET: Auditories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auditories == null)
            {
                return NotFound();
            }

            var auditory = await _context.Auditories.FindAsync(id);
            if (auditory == null)
            {
                return NotFound();
            }
            ViewData["Faculty"] = new SelectList(_context.Faculties, "Id", "Name", auditory.Faculty);
            return View(auditory);
        }

        // POST: Auditories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Floor,Number,Faculty")] Auditory auditory)
        {
            if (id != auditory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditoryExists(auditory.Id))
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
            ViewData["Faculty"] = new SelectList(_context.Faculties, "Id", "Name", auditory.Faculty);
            return View(auditory);
        }

        // GET: Auditories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auditories == null)
            {
                return NotFound();
            }

            var auditory = await _context.Auditories
                .Include(a => a.FacultyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auditory == null)
            {
                return NotFound();
            }

            return View(auditory);
        }

        // POST: Auditories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auditories == null)
            {
                return Problem("Entity set 'TimeTableContext.Auditories'  is null.");
            }
            var auditory = await _context.Auditories.FindAsync(id);
            if (auditory != null)
            {
                _context.Auditories.Remove(auditory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditoryExists(int id)
        {
          return (_context.Auditories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
