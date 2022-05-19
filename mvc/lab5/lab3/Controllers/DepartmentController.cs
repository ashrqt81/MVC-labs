using lab3.Data;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class DepartmentController : Controller
    {
        itidatabaseContext db=new itidatabaseContext();
        public IActionResult Index()
        {
           // ViewData["departments"] = db.department.ToList();//to display department data

            List<Department>depts=db.department.ToList();
            return View(depts);
        }
        //when we run first go to index action and it will go to model to get data and display it in view

        public IActionResult showAdd()//display form for user
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Department dept)//if we want to execute the create method if the request method is post[httpppost]
           
        {
            db.department.Add(dept);
            db.SaveChanges();
            //return View("index",db.department.ToList());//should send the department list
            return RedirectToAction("index");

        }
        public IActionResult Edit(int? id)//get old data
        {
            if (id == null)
                return NotFound();
           Department dept=  db.department.FirstOrDefault(a => a.DeptId == id);
            if (dept == null)
                return NotFound();
            return View(dept);//return view wz data
        }
        //we cant overload action unless we use action action selector
        [HttpPost]
        public IActionResult Edit(Department dept)//update
        {
            db.department.Update(dept);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

             
        }
        //OR
        /* public IActionResult Edit(Department dept,int id)
         {    dept.deptId==id;
             db.department.Update(dept);
             db.SaveChanges();
             return RedirectToAction(nameof(Index));


         }
         */
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Department dept = db.department.FirstOrDefault(a => a.DeptId == id);

            if (dept == null)
                return NotFound();
            // db.department.Remove(dept);
            // db.SaveChanges();
            return View(dept);
        }
        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteConfirm(int DeptId)//same input name or object of department
        {
           Department dept= db.department.FirstOrDefault(a => a.DeptId == DeptId);
            db.department.Remove(dept);
            db.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }
        public IActionResult xyz()
        { 
            return View();
        }
    }
}
