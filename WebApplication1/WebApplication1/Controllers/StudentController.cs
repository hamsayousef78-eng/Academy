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
            var students=_context.students.ToList();//navigation
            return View(students);
        }
        public IActionResult Create()
        {
            //ViewBag.department = _context.departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
          
            if (!ModelState.IsValid)
            {
                return View(student);
            }
          
            _context.students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            //ViewBag.department = _context.departments.ToList();
            var student = _context.students.Find(id);
            if(student!=null)
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
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var existingStudent = _context.students.Find(student.id);

            if (existingStudent!= null)
            {
                existingStudent.name = student.name;
                existingStudent.Email = student.Email;
                existingStudent.phone = student.phone;
                existingStudent.ImagePath = student.ImagePath;
                existingStudent.IsActive = student.IsActive;

                //_context.students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();


        }
        public IActionResult Delete(int id)
        {
            var student = _context.students.FirstOrDefault(item => item.id == id);

            if (student != null)
            {
                return View(student);
            }
            return NotFound();

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                _context.students.Remove(student);
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
            var student = _context.students.FirstOrDefault(d => d.id==id);

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
