using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string display(string name)
        { 
            return $"welcome {name}";
        }
        public int add(int ids)
        {
            return 2+ids;
        }
        public ViewResult show()
        {
            return View();
        }
        public ViewResult show1()
        {
            return View("showview");
            //return View("~/views/Student/show1.cshtml");
        }
    }
}
