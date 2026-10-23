using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseRoundController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CourseRoundController(ApplicationDbContext context)
        {
            _context = context;
        }
     
        public IActionResult Index()
        {
            var rounds = _context.courseRounds.Include(x => x.instructor).Include(c => c.course).ToList();
            return View(rounds);
        }
        public IActionResult Create()
        {
            ViewBag.instructor = _context.instructors.ToList();
            ViewBag.course = _context.courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseRound round)
        {
          if (!ModelState.IsValid)
            {
                ViewBag.instructor = _context.instructors.ToList();
                ViewBag.course = _context.courses.ToList();

                return View(round);
            }
            _context.courseRounds.Add(round);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
       
         public IActionResult Edit(int id)
        {
            ViewBag.instructor = _context.instructors.ToList();
            ViewBag.course = _context.courses.ToList();
            var round = _context.courseRounds.Find(id);
            if (round != null)
            {
                return View(round);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(CourseRound round)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.instructor = _context.instructors.ToList();
                ViewBag.course = _context.courses.ToList();
                return View(round);
            }
            var existingRound = _context.courseRounds.Find(round.id);

            if (existingRound != null)
            {
                existingRound.name = round.name;
                existingRound.instructorId = round.instructorId;
                existingRound.courseId = round.courseId;
                existingRound.startDate = round.startDate;
                existingRound.EndDate = round.EndDate;
                existingRound.capacity = round.capacity;
                existingRound.IsActive = round.IsActive;

                //_context.students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();


        }
      
        public IActionResult Details(int id)
       {
            var round = _context.courseRounds.Include(x => x.instructor).Include(c => c.course).FirstOrDefault(d => d.id == id);


            if (round != null)
           {
               return View(round);
           }
           else
           {
               return NotFound();
           }
       }
      

    }
}
