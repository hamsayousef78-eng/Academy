using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var course = _context.courses.ToList();//navigation
            return View(course);
        }
        public IActionResult Create()
        {
            //ViewBag.department = _context.departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            _context.courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            //ViewBag.department = _context.departments.ToList();
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
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            var existingCourse = _context.courses.Find(course.id);

            if (existingCourse != null)
            {
                existingCourse.name = course.name;
                existingCourse.description = course.description;
                existingCourse.category = course.category;
                existingCourse.durationHours = course.durationHours;
                existingCourse.price = course.price;
                existingCourse.ImagePath = course.ImagePath;
                existingCourse.IsActive = course.IsActive;

                //_context.students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();


        }
        public IActionResult Delete(int id)
        {
            var course = _context.courses.Include(x => x.courseRounds).
                             FirstOrDefault(d => d.id == id);

            if (course != null)
            {
                return View(course);
            }
            return NotFound();

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.courses.Find(id);
            if (course == null)
            {
                return NotFound();
             
            }
            bool hasRounds = _context.courseRounds.Any(round => round.courseId == id);
            if (hasRounds)
            {
                TempData["Error"] = "cannot delete course because has rounds";
                return RedirectToAction("index");
            }
            _context.courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var course = _context.courses.Include(x => x.courseRounds).FirstOrDefault(d => d.id == id);

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
