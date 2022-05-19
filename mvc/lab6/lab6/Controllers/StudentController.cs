using lab6.Data;
using lab6.Models;
using lab6.service;
using Microsoft.AspNetCore.Mvc;
 
namespace lab6.Controllers
{
    public class StudentController : Controller//dependent
    {
        // StudentMoc _db = new StudentMoc();
       // Istudent _db = new StudentMoc();
       Istudent _db ;//object from interface
       public StudentController(Istudent db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetStudents());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            if(ModelState.IsValid)
            {
                _db.addStudent(std);
                return RedirectToAction(nameof(Index));
            }
            return View(std); 
            
           //instance mamber can deal wz static member 
           //but static cant deal wz instance
        }
    }
}
