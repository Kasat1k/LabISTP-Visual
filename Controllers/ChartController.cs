using ISTPLab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISTPLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        public readonly TimeTableContext _context;
        public ChartController(TimeTableContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var faculties = _context.Faculties.ToList();
            List<object> catTeacher = new List<object>();
            catTeacher.Add(new[] { "Факультет", "Кількість викладчів" });
            foreach (var cat in faculties)
            {
                catTeacher.Add(new object[] { cat.Name, cat.Teachers.Count() });
            }
            return new JsonResult(catTeacher);
        }
    }
}
