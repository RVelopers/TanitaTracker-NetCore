using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NToastNotify;
using Web_NetCore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNetCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public UserController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "List of Users";
            return View();
        }

        public JsonResult New(NewUserViewModel model)
        {
//            if (ModelState.IsValid)
//            {
//                return Json();
//            }
//
//            return Json();
            _toastNotification.AddSuccessToastMessage("Same for success message");
            return Json(new { });
        }
        
        public IActionResult Roles()
        {
            throw new NotImplementedException();
        }

        public IActionResult Permissions()
        {
            throw new NotImplementedException();
        }

        public IActionResult NewModal()
        {
            return PartialView("New/_NewModal");
        }
    }
}
