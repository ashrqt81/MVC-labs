using Microsoft.AspNetCore.Mvc;
using lab2.Models;

namespace lab2.Controllers
{
    public class StudentController : Controller
    {
        //model binder(parameters & resourses)searching for any resourse client could send data in
        // first->route data
        //query string

        public ViewResult Display()
        {
            return View();
        }
        /*
        public ViewResult show(int? id,string fname,string lname,int age)
        {
            //Request.QueryString.Value["id"] = id;
            ViewData["id"] = id;
            ViewData["fullname"] = fname+ " "+ lname;
            ViewData["age"] = age;
           
            return View();
        }
        */
        public ViewResult add()
        {
            return View();
        }
        //bind on array of courses
        public IActionResult show2(IFormFile stdfile,  Students std1,string[] courses,Students std2)
        {
            using (var fs=new FileStream("./wwwroot/images/"+stdfile.FileName, FileMode.Create))
            {
                stdfile.CopyTo(fs);
            }
          ViewData["imgname"] = stdfile.FileName;
            ViewData["std1"] = std1;
            
            ViewData["course"] = courses;//********display array of courses in view
                                         //ViewData["stdfile"]
            ViewData["std2"] = std2;

            if (std1.Id == 1)//json and view both implement iactionresult
                return Json(std1);
























































































































































































































































































































































































































































            else
                //************************try return file
              // return RedirectToAction("Display");
               // return Redirect("http://www.google.com");
                //return StatusCode(200);
               // return NotFound();
               // return Content($"{std1.fname} { std1.lname}"); return string
            return View();
        }
    }
}
//how controller(action) send data to view
// each of them have view data (dictionary)dic. in controller send data
//and dic. in view recive it

