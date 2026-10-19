using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.departments.ToList();//navigation
            return View(departments);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
        
            var department = _context.departments.Find(id);
            if (department != null)
            {
                return View(department);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _context.departments.Update(department);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var department = _context.departments.Find(id);
            if (department != null)
            {
                _context.departments.Remove(department);
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
            var department = _context.departments.Include(s => s.students).FirstOrDefault(x => x.id == id);
            if (department != null)
            {
                return View(department);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
