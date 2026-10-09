using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students=_context.students.Include(x=>x.department).ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            ViewBag.depart = _context.departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.students.Add(student);
           _context.SaveChanges();//عشان تتحفظ في ال DB
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.depart = _context.departments.ToList();
            var student = _context.students.Find(id);
            if(student !=null)
            {
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                _context.students.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Details(int id)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
