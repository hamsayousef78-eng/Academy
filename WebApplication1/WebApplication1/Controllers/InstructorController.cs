using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InstructorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var instructor = _context.instructors.ToList();//navigation
            return View(instructor);
        }
        public IActionResult Create()
        {
            //ViewBag.department = _context.departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {

            if (!ModelState.IsValid)
            {
                return View(instructor);
            }

            _context.instructors.Add(instructor);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            //ViewBag.department = _context.departments.ToList();
            var instructor = _context.instructors.Find(id);
            if (instructor != null)
            {
                return View(instructor);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return View(instructor);
            }
            var existingInstructor = _context.instructors.Find(instructor.id);

            if (existingInstructor != null)
            {
                existingInstructor.name = instructor.name;
                existingInstructor.Email = instructor.Email;
                existingInstructor.phone = instructor.phone;
                existingInstructor.specialization = instructor.specialization;
                existingInstructor.bio = instructor.bio;
                existingInstructor.ImagePath = instructor.ImagePath;
                existingInstructor.IsActive = instructor.IsActive;

                //_context.students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();


        }
        public IActionResult Delete(int id)
        {
            var instructor = _context.instructors.FirstOrDefault( d => d.id==id);

            if (instructor != null)
            {
                return View(instructor);
            }
            return NotFound();

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = _context.instructors.Find(id);
            if (instructor != null)
            {
                _context.instructors.Remove(instructor);
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
            var instructor = _context.instructors.FirstOrDefault(d => d.id == id);

            if (instructor != null)
            {
                return View(instructor);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
