namespace Demo.Controllers
{
    public class AccountController : Controller
    {
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
