using lab3.Data;
using lab3.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab3.Controllers
{
    public class StudentController : Controller
    {
        itidatabaseContext db=new itidatabaseContext();
        
            public IActionResult Index()
            {

                //inclue "eager load" we want to get students wz their departments
                //relatiion one to many
                //another way wz linq//var z = db.student.select(x=>new{x.id,x.name,x.department.name}).tolist() 
               
                return View(db.students.Include(a => a.department).ToList());
            }
        public IActionResult Create()
        {
            
            //ViewBag wrapper above viewdata
            ViewBag.depts = new SelectList(db.department.ToList(), "DeptId", "Name");
            return View();
        }
        [HttpPost]
        //model binder not only collect the data but also validate it based on the constarints we put on the model
        //as it create a dictionary called model state check if vaild and if not return student data in a view

        public IActionResult Create(Student students, IFormFile StdImg)

        {
           if(StdImg ==null)
                ModelState.AddModelError("","image is required");
            
           if(ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                string[] arr = StdImg.FileName.Split('.');//get extension
                string filename = students.Id.ToString() + "." + arr[arr.Length - 1];
                using (var fs = new FileStream("./wwwroot/images/" + filename, FileMode.Create))
                {
                    StdImg.CopyTo(fs);
                }
                students.StdImg = filename;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //send the list again
            ViewBag.depts = new SelectList(db.department.ToList(), "DeptId", "Name",students.deptno);
             return View(students);
           
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
         Student std=   db.students.Include(a => a.department).FirstOrDefault(a => a.Id == id);
            if (std is null)
                return NotFound();
            return View(std);
        }
        
       
        public IActionResult checkUsername(string Username)
        {
 
            Student std = db.students.FirstOrDefault(a => a.Username == Username);


            if (std == null)
                return Json(true);
            else
                return Json(false);
        }
        public IActionResult Delete( int ? id)
        {
            if (id == null)
                return NotFound();
          Student std=  db.students.FirstOrDefault(a => a.Id == id);
            if (std == null)
                return NotFound();
            db.students.Remove(std);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        ///EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
           
            Student std = db.students.Include(a => a.department).FirstOrDefault(i => i.Id == id);
            if (std == null)
                return NotFound();
            ViewBag.depts = new SelectList(db.department.ToList(), "DeptId", "Name", std.deptno);
            
            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            db.students.Update(student);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult EditUserName(int? id)
        {
            if (id == null)
                return NotFound();
            Student std= db.students.Include(d=>d.department).FirstOrDefault(a=>a.Id==id);
            if (std == null)
                return NotFound();
            ViewBag.depts = new SelectList(db.department.ToList(), "DeptId", "Name", std.deptno);
            return View(std);
        }
        [HttpPost]
        public IActionResult EditUserName(Student std)
        {
            db.students.Update(std);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      
       public IActionResult EditImage(int? id)
       {
           if (id == null)
               return NotFound();
           Student std =db.students.Include(d=>d.department).FirstOrDefault(a=>a.Id == id);

           if (std == null)
               return NotFound();
          ViewBag.depts = new SelectList(db.department.ToList(), "DeptId", "Name", std.deptno);
           return View(std);
       }
        [HttpPost]
        public IActionResult EditImage(Student std, IFormFile stdImg)
        {
           

            if (stdImg == null)
                ModelState.AddModelError("", "image is required");

            

            if (ModelState.IsValid)
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/images/", "31.png");

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                string[] arr = stdImg.FileName.Split('.');
                string filename = std.Id.ToString() + "." + arr[arr.Length - 1];
                using (var stdd = new FileStream("./wwwroot/images/" + filename, FileMode.Create))
                {
                    stdImg.CopyTo(stdd);
                }
                std.StdImg = filename;
                //db.students.Update(std);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        /*if(StdImg ==null)
                ModelState.AddModelError("","image is required");
            
           if(ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                string[] arr = StdImg.FileName.Split('.');//get extension
                string filename = students.Id.ToString() + "." + arr[arr.Length - 1];
                using (var fs = new FileStream("./wwwroot/images/" + filename, FileMode.Create))
                {
                    StdImg.CopyTo(fs);
                }
                students.StdImg = filename;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //send the list again
            ViewBag.depts = new SelectList(db.department.ToList(), "DeptId", "Name",students.deptno);
             return View(students);*/


    }
}
