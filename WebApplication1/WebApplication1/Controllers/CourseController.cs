using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.courses.ToList();//navigation
            return View(courses);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {

            var course = _context.courses.Find(id);
            if (course != null)
            {
                return View(course);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            _context.courses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var course = _context.courses.Find(id);
            if (course != null)
            {
                _context.courses.Remove(course);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Details(int id)
        {
            var course = _context.courses.Find(id);
            if (course != null)
            {
                return View(course);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
