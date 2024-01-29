using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PassDataController : Controller
    {
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
    }
}
