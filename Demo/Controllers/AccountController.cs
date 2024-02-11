using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
                    //add user to role Admin (DB userManager)
                     await userManager.AddToRoleAsync(user, "Admin");

                    List<Claim> Claims = new List<Claim>();
                    Claims.Add(new Claim("Address", userVM.Address));
                    //add anoth claims to cookie per user
                    await signInManager.SignInWithClaimsAsync(user, false, Claims);
                    //  await  signInManager.SignInAsync(user, false);/*Id,Name,Role*/
                    return RedirectToAction("ShowUserData", "Employee");
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

        //Login Action
        [HttpGet]//open login form
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]//open login form
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel uservm)
        {
            if(ModelState.IsValid)
            {
                //check account valid
                ApplicationUser UserModel=
                    await userManager.FindByNameAsync(uservm.UserNAme);
                if (UserModel!=null)//exist with this name
                {
                    bool found =await userManager.CheckPasswordAsync(UserModel, uservm.PAssword);
                    if (found)
                    {
                        await signInManager.SignInAsync(UserModel, uservm.RememberMe);
                        return RedirectToAction("Index", "Employee");
                        #region Sign in & Check
                        //var result= await  signInManager
                        //    .CheckPasswordSignInAsync(UserModel, uservm.PAssword, false);
                        //   if (result.Succeeded)
                        // {
                        // return RedirectToAction("Index", "Employee");
                        //}
                        #endregion
                    }
                }
                ModelState.AddModelError("", "Invalid Account username or passwrod");
                
            }
            return View(uservm);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }





        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        ////pervent any external request
        //[ValidateAntiForgeryToken]//developer
        //public IActionResult Login(UserAccount user)
        //{
        //    if(user.UserNAme=="Ahmed" && user.Password=="123")
        //        return RedirectToAction("Index","Employee");
        //    else
        //        return View();
        //}
    }
}
