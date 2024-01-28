namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> DEptListMode= context.Departments.ToList();
            //return View("Index", DEptListMode);  //View =Index ,Model ==>List<Department>
            return View(DEptListMode);           //View =Index , Model ==>List <Department>

            //return View("Index");                //View =Index ,Model ==>null wrong
            //return View();                        //View=Index ,Model==>null
        }

        public IActionResult Details(int id)
        {
            //get depart info
            Department deptModel = context.Departments.FirstOrDefault(d => d.Id == id);
            //--------------------Extra info send C# To HTML-----------------
            List<string> Branches=new    List<string>();
            Branches.Add("Cairo");
            Branches.Add("MEnua");
            Branches.Add("Alex");
            Branches.Add("Sohag");

            ViewData["brch"] = Branches;    
            ViewData["Message"] = "Hello";
            ViewData["clr"] = "red";
            ViewData["temp"] = 20;
            ViewData["Date"] = DateTime.Now;


            return View("Details", deptModel);//view==DEtails ,Model  department
        }

    }
}
