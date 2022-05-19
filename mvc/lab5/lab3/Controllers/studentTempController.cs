using Microsoft.AspNetCore.Mvc;
using lab3.Data;
using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Controllers
{
    public class studentTempController : Controller
    {
        itidatabaseContext db = new itidatabaseContext();
        public IActionResult doWork1()
        {
            Department dept = db.department.SingleOrDefault(a => a.DeptId == 1);
            //get department number1
          //  StudentController std = new StudentController() { Name = "galal", age = "77", deptno =2 };
          //  db.students.Add(std);
            db.SaveChanges();
           // dept.students.Add(std);//change student department number 
            db.SaveChanges();


            //db.department.Add(new Department() { DeptId = 2, Capacity = 300, Name = "SD" });
            
            db.SaveChanges();
            return Content("added");
        }
        public IActionResult doWork2()
        {
            // Student std=db.students.FirstOrDefault(a=>a.Id == 1); lazyload
          //  StudentController std = db.students.Include(a => a.department).FirstOrDefault(a => a.Id == 1);
            return Content("added");
        }
        public IActionResult dowork3()
        {
            //Student std = db.students.FirstOrDefault(a => a.Id == 1);
           
            //course c = db.courses.FirstOrDefault(a => a.courseId == 1);

           // db.SaveChanges();
           
            db.studentsCourse.Add(new studentCourse() { stdId = 3,crsId=2 });
            db.SaveChanges();

            return Content("added");
        }
    }
}
