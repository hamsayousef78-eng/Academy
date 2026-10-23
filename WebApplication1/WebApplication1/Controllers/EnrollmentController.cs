using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
        public IActionResult Index()
        {
            //var enrollments = _context.enrollments.Include(x => x.student).Include(c => c.course).ToList();
            //return View(enrollments);
        }
        public IActionResult Create()
        {
            ViewBag.student = _context.students.ToList();
            ViewBag.course = _context.courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            _context.enrollments.Add(enrollment);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        */
    }
}
