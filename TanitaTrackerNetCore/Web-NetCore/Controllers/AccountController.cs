using Microsoft.AspNetCore.Mvc;

namespace Web_NetCore.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }
        
        // GET
        public IActionResult Logout()
        {
            return Redirect("Login");
        }
    }
}