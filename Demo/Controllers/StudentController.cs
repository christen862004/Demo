using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {

        //display
        //student/all
        public IActionResult All()
        {
            //ask model
            List<Student> StudentListModel= StudentSampleData.GetAll();
            //send view
            //return View("ShowAll");//View ==ShowAll  Model =Null
            return View("ShowAll", StudentListModel);//View ==ShowAll
                                                     //Model =StudentListModel

        }


        //Student/Details/1
        //Student/Details?id=1
        public IActionResult DEtails(int id)
        {
            Student studentModel=
                StudentSampleData.GetByID(id);
            return View("Details",studentModel);
            //View = DEtails
            //Model = Student Type
        }


        //Method: ==> Action
        //1- Must be public 
        //2- Cant be static
        //3- Cant be overload (case one )
        //Student/getMsg
        //public string GetMsg()
        //{
        //    return "Hello World";
        //}

        public ContentResult getmsg()
        {
            //declare
            ContentResult result = new ContentResult();
            //set
            result.Content = "Hello World";
            //return
            return result;
        }
        public ViewResult getView()
        {
            //decalre
            ViewResult result = new ViewResult();
            //set
            result.ViewName = "View1";
            //resturn
            return result;
        }
        //Student/getMix/1?age=12
        //Student/getMix?id=1&age=12

        
        public IActionResult getMix(int id,int age)
        {
            if(id%2 ==0)
            {
                //logic
                return View("View1");
            }
            else
            {
                return Content("Hello World");
            }
        }



        //differnt type action can return ActionREsult : IActionres
        //1- Content    ===> ContentResult
        //2- View       ===> ViewResult
        //3- Json       ===> JsonREsult
        //4- Javascript ===> JAvascriptReuslt
        //5- Void       ===> EmptyResult
        //6- notfound   ===> NotFoundResult
        //7- file   .....
    }
}
