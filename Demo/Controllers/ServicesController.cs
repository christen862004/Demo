using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ServicesController : Controller
    {
        private  IDepartmentRepository deptRepo;

        public ServicesController(IDepartmentRepository DEptRepo)
        {
            deptRepo = DEptRepo;
        }

        public IActionResult Index()//[FromServices]IDepartmentRepository DEptRepo)//inject metohd
        {
            ViewData["Id"] = deptRepo.Id;
            return View();
        }
    }
}
