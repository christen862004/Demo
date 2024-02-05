//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
   // [Route("r1/{action=Method1}")]
    public class RouteController : Controller
    {
        //m1/ahmed/33 ==> litteral keyword ==>Map
        //m1/ali/22
        //m1/basma/12
        //route/method1?name=ahmed
        //R1/Mehtod1
       // [Route("m1/{stdName:apha}/{age?}",Name ="Rout2")]
        public IActionResult Method1(string stdName,int age)
        {
            return Content("Method1");
        }
        //R1/Mehtod2
        [HttpGet("r1/{name:alpha}")]
        //[Route("r1")]
        public IActionResult Method2()
        {
            return Content("Method2");
        }
    }
}
