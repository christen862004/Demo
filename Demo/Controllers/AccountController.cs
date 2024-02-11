using Microsoft.AspNetCore.Identity;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        //Ask IOC Container
        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //Registration
        public IActionResult Register()
        {
            //open form
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//submit
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userVM.UserName; ;
                user.PasswordHash = userVM.Password;
                user.Address = userVM.Address;
                
                IdentityResult result= await userManager.CreateAsync(user,userVM.Password);

                if (result.Succeeded)
                {
                    //create cookie Authanticated User "Craete Cookie"
                    await  signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    //get errors send view as error
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);//error send to view 
                    }
                }
                //-------------
            }
            return View(userVM);//view (Model ,Modelstate Error)
        }



        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //pervent any external request
        [ValidateAntiForgeryToken]//developer
        public IActionResult Login(UserAccount user)
        {
            if(user.UserNAme=="Ahmed" && user.Password=="123")
                return RedirectToAction("Index","Employee");
            else
                return View();
        }
    }
}
