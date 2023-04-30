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
    public class TimetablesController : Controller
    {
        private readonly TimeTableContext _context;

        public TimetablesController(TimeTableContext context)
        {
            _context = context;
        }

        // GET: Timetables
        public async Task<IActionResult> Index()
        {
            var timeTableContext = _context.Timetables.Include(t => t.AuditoryNavigation).Include(t => t.GroupTtNavigation).Include(t => t.SubjectNavigation).Include(t => t.TeacherNavigation);
            return View(await timeTableContext.ToListAsync());
        }

        // GET: Timetables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timetables == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetables
                .Include(t => t.AuditoryNavigation)
                .Include(t => t.GroupTtNavigation)
                .Include(t => t.SubjectNavigation)
                .Include(t => t.TeacherNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timetable == null)
            {
                return NotFound();
            }

            return View(timetable);
        }

        // GET: Timetables/Create
        public IActionResult Create()
        {
            ViewData["Auditory"] = new SelectList(_context.Auditories, "Id", "Number");
            ViewData["GroupTt"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["Subject"] = new SelectList(_context.Subjects, "Id", "Name");
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name");
            return View();
        }

        // POST: Timetables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Auditory,GroupTt,Teacher")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timetable);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["Auditory"] = new SelectList(_context.Auditories, "Id", "Number", timetable.Auditory);
            ViewData["GroupTt"] = new SelectList(_context.Groups, "Id", "Name", timetable.GroupTt);
            ViewData["Subject"] = new SelectList(_context.Subjects, "Id", "Name", timetable.Subject);
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name", timetable.Teacher);
            return View(timetable);
        }

        // GET: Timetables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timetables == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable == null)
            {
                return NotFound();
            }
            ViewData["Auditory"] = new SelectList(_context.Auditories, "Id", "Number", timetable.Auditory);
            ViewData["GroupTt"] = new SelectList(_context.Groups, "Id", "Name", timetable.GroupTt);
            ViewData["Subject"] = new SelectList(_context.Subjects, "Id", "Name", timetable.Subject);
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name", timetable.Teacher);
            return View(timetable);
        }

        // POST: Timetables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Auditory,GroupTt,Teacher")] Timetable timetable)
        {
            if (id != timetable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timetable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimetableExists(timetable.Id))
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
            ViewData["Auditory"] = new SelectList(_context.Auditories, "Id", "Number", timetable.Auditory);
            ViewData["GroupTt"] = new SelectList(_context.Groups, "Id", "Name", timetable.GroupTt);
            ViewData["Subject"] = new SelectList(_context.Subjects, "Id", "Name", timetable.Subject);
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "Name", timetable.Teacher);
            return View(timetable);
        }

        // GET: Timetables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timetables == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetables
                .Include(t => t.AuditoryNavigation)
                .Include(t => t.GroupTtNavigation)
                .Include(t => t.SubjectNavigation)
                .Include(t => t.TeacherNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timetable == null)
            {
                return NotFound();
            }

            return View(timetable);
        }

        // POST: Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timetables == null)
            {
                return Problem("Entity set 'TimeTableContext.Timetables'  is null.");
            }
            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable != null)
            {
                _context.Timetables.Remove(timetable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimetableExists(int id)
        {
          return (_context.Timetables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
