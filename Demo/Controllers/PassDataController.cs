using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PassDataController : Controller
    {
        //PassData/MEthod1 :GEt
        [HttpGet]
        public IActionResult Method1()
        {
            return Content("Method1");
        }
        //PassData/MEthod1 :Post
        [HttpPost]
        public IActionResult Method1(int id)//request.form =>routeValue =>Quer =0
        {
            return Content("Method1_1");
        }



        public IActionResult SetSession()
        {
            //logic
            //Satemanagemnt
            //object ==>json
            HttpContext.Session.SetString("Name", "Christen");
            HttpContext.Session.SetInt32("Age", 33);
            return Content("Session saved");
        }
        public IActionResult GetSession()
        {
            //logic
            //Satemanagemnt
            //object ==>json
            string name=HttpContext.Session.GetString("Name");//, "Christen");
            int age= HttpContext.Session.GetInt32("Age").Value;//, 33);
            return Content($"name={name} \n age={age}");
        }



        public IActionResult SetCookie()
        {
            //db - logic
            //statemangement
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("name", "Ahmed",options);//Session Cookie     
            HttpContext.Response.Cookies.Append("Age", "12", options);//Persistent Cookie
            //2 Type of Cookie
                //1) session cookie
                //2) Presisitent Cookie :== Expirstion
            return Content("Cookie SAved");
        }

        public IActionResult GetCookie()
        {
            //logic
            string name=  HttpContext.Request.Cookies["name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"REad Cookie name={name} age={age}");
        }
    }
}
