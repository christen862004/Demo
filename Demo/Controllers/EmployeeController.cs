using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        //calling using ajax ==> using dom(js)
        public IActionResult GEtPartialDetails(int id)
        {
            Employee EmpMode =
                context.Employees.FirstOrDefault(e => e.Id == id);
            // return View("_EmpCardPartial",EmpMode);//Viewstart ==>Layout
            return PartialView("_EmpCardPartial", EmpMode);//Not Layout
        }


        public IActionResult DEtails(int id)
        {
            Employee EmpMode = context.Employees.FirstOrDefault(e => e.Id == id);
            return View(EmpMode);
        }


        public IActionResult Detele(int id)
        {
            Employee EmpMode = context.Employees.FirstOrDefault(e => e.Id == id);
            return View(EmpMode);
        }


        public IActionResult ConfirmDelte(int id)
        {
            //DElete Employee
            return RedirectToAction("Index");
        }




        public IActionResult Index()
        {
            List<Employee> EmpList = context.Employees.ToList();
            return View(EmpList);
        }
        //open form
        public IActionResult Edit(int id) {
            Employee EmpModel=context.Employees.FirstOrDefault(x => x.Id == id);
            ViewData["DeptList"] = context.Departments.ToList();
            return View(EmpModel);//view =Edit ,model =Employee
        }
        //save database
        [HttpPost]
        public IActionResult SaveEdit(Employee Emp)
        {
            if (Emp.Name != null)
            {
                context.Update(Emp);
                context.SaveChanges();//
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", Emp);
            }
        }
        
        [HttpGet]//Link
        public IActionResult New()
        {
            ViewData["DeptList"] = context.Departments.ToList();
            return View();//NEw ,Model=Null
        }

        [HttpPost]//Submit
        public IActionResult New(Employee Emp)
        {
            try
            {
                //if (Emp.Name != null && Emp.Salary>2000)
                if(ModelState.IsValid==true)//Validation server side
                {
                        context.Add(Emp);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //send expection details in firendly form
                ModelState.AddModelError("DepartmentID", "Select DEpartment :)");// ex.Message);
            }
            ViewData["DeptList"] = context.Departments.ToList();
            return View(Emp);//Emp ,viewDAta ,viewbag ==>MOdelState
        }

        public IActionResult CheckSalary(int Salary ,int Age)
        {
            //logic databse
            if (Salary > 2000 && Age > 30)
            {
                return Json(true);
            }else if(Salary > 5000 && Age > 40)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
