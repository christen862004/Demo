using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    
    public class EmployeeController : Controller
    {
       


        //ITIContext context = new ITIContext();
        IEmployeeRepository EmployeeRepository;
        IDepartmentRepository DepartmentRepository;
        //DI : Dont create ,but ask "Inject"
        public EmployeeController(IEmployeeRepository _empREpo, IDepartmentRepository _deptREpo)
        {
            this.EmployeeRepository= _empREpo;
            this.DepartmentRepository= _deptREpo;
            //EmployeeRepository = new EmployeeRepository();
            //DepartmentRepository = new DepartmentRepository();
        }

        //calling using ajax ==> using dom(js)
        
        public IActionResult GEtPartialDetails(int id)
        {
            Employee EmpMode =
                EmployeeRepository.GetByID(id);
            // return View("_EmpCardPartial",EmpMode);//Viewstart ==>Layout
            return PartialView("_EmpCardPartial", EmpMode);//Not Layout
        }


        public IActionResult DEtails(int id)
        {
            Employee EmpMode = EmployeeRepository.GetByID(id); ;
            return View(EmpMode);
        }


        public IActionResult Detele(int id)
        {
            Employee EmpMode = EmployeeRepository.GetByID(id); ;
            return View(EmpMode);
        }


        public IActionResult ConfirmDelte(int id)
        {
            //DElete Employee
            return RedirectToAction("Index");
        }



        
        public IActionResult Index()
        {
            List<Employee> EmpList =EmployeeRepository.GetAll(null);
            return View(EmpList);
        }
        //open form
        public IActionResult Edit(int id) {
            Employee EmpModel = EmployeeRepository.GetByID(id); ;
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View(EmpModel);//view =Edit ,model =Employee
        }
        //save database
        [HttpPost]
        public IActionResult SaveEdit(Employee Emp)
        {
            if (Emp.Name != null)
            {
                EmployeeRepository.Edit(Emp);
                EmployeeRepository.Save();
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
            ViewData["DeptList"] = DepartmentRepository.GetAll();
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
                    EmployeeRepository.Insert(Emp);
                    EmployeeRepository.Save();
                        return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //send expection details in firendly form
                ModelState.AddModelError("DepartmentID", "Select DEpartment :)");// ex.Message);
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
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
