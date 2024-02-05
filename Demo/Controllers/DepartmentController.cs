using Demo.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    //DIP
    public class DepartmentController : Controller
    {
        //  ITIContext context = new ITIContext();
        IDepartmentRepository DeptRepo;
        IEmployeeRepository EmployeeRepo;
        //DI
        //Contrller Factory (ctor)
        public DepartmentController
            (IDepartmentRepository _DeptRepo, IEmployeeRepository _EmployeeRepo)
        {
            DeptRepo = _DeptRepo;//DIP
            EmployeeRepo = _EmployeeRepo;
        }
        //Depart,ent/GetEmps?DEptid=1
        public IActionResult GetEmps(int DeptID)
        {
            var EmpListMode=
                EmployeeRepo.FindByDeptID(DeptID).Select(e => new {e.Id,e.Name}).ToList();
            return Json(EmpListMode);
        }

        public IActionResult Index()
        {
            List<Department> DEptListMode = DeptRepo.GetAll();
            //return View("Index", DEptListMode);  //View =Index ,Model ==>List<Department>
            return View(DEptListMode);             //View =Index , Model ==>List <Department>
            //return View("Index");                //View =Index ,Model ==>null wrong
            //return View();                        //View=Index ,Model==>null
        }
        public IActionResult New()//open form
        {
            return View();//View = "New" ,Model= null
        }
        //Department/SAveNew?name=sd&managername=ahmed
        //Can handel any request type(Post)
        [HttpPost]
        public IActionResult SaveNew(Department department)
        {
            if (department.Name != null)//Validation
            {
                DeptRepo.Insert(department);
                DeptRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New",department);//view = New ,Model =DEpartment
            }
        }

        public IActionResult Details(int id)
        {
            //get depart info
            Department deptModel = DeptRepo.GetByID(id);
            //--------------------Extra info send C# To HTML-----------------
            List<string> Branches=new    List<string>();
            Branches.Add("Cairo");
            Branches.Add("MEnua");
            Branches.Add("Alex");
//            Branches.Add("Sohag");

            ViewData["brch"] = Branches;    
            ViewData["Message"] = "Hello";
            ViewData["clr"] = "red";
            ViewData["temp"] = 20;
            ViewData["Date"] = DateTime.Now;

            ViewBag.age = 25;
            ViewBag.clr = "green";

            return View("Details", deptModel);//view==DEtails ,Model  department
        }

        public IActionResult DetailsWithVM(int id) {
            /*depart name -clor -brch -temp -date*/
            List<string> Branches = new List<string>();
            Branches.Add("Cairo");
            Branches.Add("MEnua");
            Branches.Add("Alex");
            Branches.Add("Sohag");

            Department deptModel =
                DeptRepo.GetByID(id);//source fill vm

            DepartmentNAmeWithClrBrachTempViewModel deptVm =
                new DepartmentNAmeWithClrBrachTempViewModel();
            //mapping "automapper"
            deptVm.DeptName = deptModel.Name;
            deptVm.DeptId = deptModel.Id;
            deptVm.Color = "red";
            deptVm.Branches= Branches;
            deptVm.Temp = 20;

            return View(deptVm);//view name= DetailsWithVM ,Model = DepartmentNAmeWithClrBrachTempViewModel
        }
    }
}
