using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    public class DepartmentController : Controller
    {
        [Route("hamada/{action}")]
        public IActionResult Index()
        {
            //ViewBag.id = 10; can see data in index view only
            //better way to send data from action to view 
            TempData["id"] = 10;//can see data from any view
            return View();
        }
        public IActionResult show()
        {
            return View();
        }
        public IActionResult show2()
        {
            ViewBag.id=TempData["id"];
            return View(); 
        }
        public IActionResult dowork1()
        {
            //when there is a requset like student/dowork1
            //cookies is an object ,created in server and sent in the response that sent to the client which will be saved in the cookies of the client's browser
            //and wz any request client will make this cookies will be sent to the server again

            //server
            //set cookies duration
            CookieOptions cp = new CookieOptions() { Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append("id", "1200",cp);
            Response.Cookies.Append("name", "aly",cp);
            Response.Cookies.Append("age", "30",cp);
            return Content("dowork1");
        }
        public IActionResult dowork2()
        {//note: cookies always return string
            string name = Request.Cookies["name"];
          int age= int.Parse( Request.Cookies["age"]);
            //return Content("name is " + name+"and age  is "+age);
            return Content($"name is { name } age is { age }");
        }
        //how to save object in cookies a"save sensetive sata like password"=>use seesion
        //that save data in the server
        //when there is a req between client and server the server save client data which came from specific browser
        //because with session client data saved in server not with client so how server know that this data s belong to thst client

        //** action that set session**use session to save sensitive data
        public IActionResult dowork3( int id=9, string name = "nasr")
        {
           
            //httpcontext object represent request and response
            HttpContext.Session.SetString("name",name);
            HttpContext.Session.SetInt32("id", id);
            return Content("data added");
        }
        //** action that read  session data**
        public IActionResult dowork4()
        {
            string name = HttpContext.Session.GetString("name");
            int id = HttpContext.Session.GetInt32("id").Value;
            return Content($"data added{ name} id is {id}");
        }
        //but first to use session you need to go to program file and add use session and builder.service.addsession

    }
}
