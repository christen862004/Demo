using Demo.Filtters;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [HandelError]
    public class FilterController : Controller
    {
        
        public IActionResult Index()
        {
            throw new NotImplementedException();
            
        }
        
        public IActionResult Index2()
        {
            throw new NotImplementedException();
        }
    }
}
