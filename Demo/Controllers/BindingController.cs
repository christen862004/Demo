using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BindingController : Controller
    {
        //Model Binding (Get data from request Bind Action Parameter)
        //Type binding
        //Prmitive data type (int ,float ,string ....)
        //REquest:Binding/TestPrimitive?age=12&name=Ahmed&id=1

        //REquest:Binding/TestPrimitive/1?color[1]=blue&age=12&name=Ahmed&color[0]=red
        public IActionResult TestPrimitive(int age,string name,string[] color,int id)
        {
            return Content("Get Data");
        }
        /*
         1) Request.form
         2) Request.RoutValue (Controller : Binding,Action : TestPrimitive,Id:1)
         3) Request.QueryString
         4) default
         */


        //binding Collection (list dic)
        //Binding/TestDic?phone[ahmed]=1234&phone[sara]=56789
        public IActionResult TestDic(Dictionary<string,string> phone,string className)
        {
            return Content("Save");
        }

        //Binding Custom Type "Class Model"
        //Binding/testobj?id=1&name=SD&ManagerName&color=red&Employees[0].name=asd
        public IActionResult TestObj
            (Department department,string color,string name)
        {
            return Content("SAve");
        }

    }
}
