using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager)
        {
            this.RoleManager = RoleManager;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleCreateViewModel newRole)
        {
            //Save Role Table
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newRole.RoleName;
                IdentityResult result= await  RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    //RedirectToAction("Add");
                    RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newRole);
        }
    }
}
