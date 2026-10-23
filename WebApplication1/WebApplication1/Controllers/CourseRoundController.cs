using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CourseRoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
