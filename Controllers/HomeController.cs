using ISTPLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml;

namespace ISTPLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TimeTableContext _context;

        public HomeController(ILogger<HomeController> logger , TimeTableContext context)
        {
            _logger = logger;
            _context = context;
        }
      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> TimeTables([Bind("GroupTt")] Timetable timetable)
        {
            var timetablessByGroup = _context.Timetables.Where(t => t.GroupTt == timetable.GroupTt).Include(t => t.GroupTtNavigation).Include(t=>t.SubjectNavigation).Include(t=>t.AuditoryNavigation).Include(t=>t.TeacherNavigation);
            return View(await timetablessByGroup.ToListAsync());
        }

        public async Task<IActionResult> GroupChoose() 
        {
            ViewData["GroupCh"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Acception()
        {
            return View();
        }

        public async Task<IActionResult> ValidationPass(string Password)
        {
            if (Password == "Admin") return RedirectToAction("Admin", "Home");
            else return RedirectToAction("WrongPass", "Home");
        }
        public async Task<IActionResult> Admin()
        {
            ViewData["GroupCh"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> WrongPass() { return View(); }
        public async Task<IActionResult> ErrorM() { return View(); }
        public async Task<IActionResult> DetailsUser() { return View(); }
    }
}