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

        public IActionResult Index()
        {
            var enrollments = _context.enrollments.Include(x => x.student).Include(c => c.courseRound).
                                ThenInclude(c => c.course).ToList();
            return View(enrollments);
        }

        public IActionResult Create()
        {

            ViewBag.student = _context.students.ToList();
            //ViewBag.course = _context.courses.ToList();
            ViewBag.courseRound = _context.courseRounds.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.student = _context.students.ToList();
                //ViewBag.course = _context.courses.ToList();
                ViewBag.courseRound = _context.courseRounds.ToList();

                return View(enrollment);
            }
            _context.enrollments.Add(enrollment);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            ViewBag.student = _context.students.ToList();
            ViewBag.courseRound = _context.courseRounds.ToList();
            var enrollment = _context.enrollments.Find(id);
            if (enrollment != null)
            {
                return View(enrollment);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.student = _context.students.ToList();
                ViewBag.courseRound = _context.courseRounds.ToList();
                return View(enrollment);
            }
            var existingEnrollment = _context.enrollments.Find(enrollment.id);

            if (existingEnrollment != null)
            {
                existingEnrollment.studentId = enrollment.studentId;
                existingEnrollment.courseRoundId = enrollment.courseRoundId;
                existingEnrollment.enrollmentDate = enrollment.enrollmentDate;

                //_context.students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();


        }
        public IActionResult Delete(int id)
        {
            var enrollment = _context.enrollments.Include(x => x.student).Include(c => c.courseRound).
                               ThenInclude(c => c.course).FirstOrDefault(x => x.id == id);
            if (enrollment != null)
            {
                return View(enrollment);
            }
            return NotFound();

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var enrollment = _context.enrollments.Find(id);
            if (enrollment == null)
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
            var enrollment = _context.enrollments.Include(x => x.student).Include(c => c.courseRound).
                               ThenInclude(c => c.course).FirstOrDefault(x => x.id == id);

            if (enrollment != null)
            {
                return View(enrollment);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
    
