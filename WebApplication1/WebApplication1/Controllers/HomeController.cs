using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag. studentCount = _context.students.Count();
            ViewBag. instructorCount = _context.instructors.Count();
            ViewBag. courseCount = _context.courses.Count();
            ViewBag. roundCount = _context.courseRounds.Count();
            var rounds = _context.courseRounds.Include(x => x.instructor).Include(c => c.course).ToList();
            return View(rounds);
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
    }
}
