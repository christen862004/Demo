using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
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
            //id ,name,salary,deptId + List<Department>  
        }
        //save database
        [HttpPost]
        public IActionResult SaveEdit(Employee Emp)
        {
            if (Emp.Name != null)
            {
                context.Update(Emp);
                context.SaveChanges();
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
            if (Emp.Name != null)
            {
                context.Add(Emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.Departments.ToList();
            return View(Emp);
        }
    }
}
