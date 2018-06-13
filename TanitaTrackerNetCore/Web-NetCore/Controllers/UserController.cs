using System;
using System.Linq;
using AppService.Dto;
using AppService.Services;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Web_NetCore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNetCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IUserService _userService;


        public UserController(IToastNotification toastNotification, IUserService userService)
        {
            _toastNotification = toastNotification;
            _userService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "List of Users";
            return View();
        }

        public JsonResult New(NewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new CreateUserDto
                {
                    FirstName = model.FirtsName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Height = model.Height
                };
                var result = _userService.CreateUser(user);
                _toastNotification.AddSuccessToastMessage(result.Message);
                return Json(new { });

            }
//            return Json();
            _toastNotification.AddErrorToastMessage(GetModelStateErrors());
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
        
        private string GetModelStateErrors()
        {
            return string.Join(" ", ModelState.SelectMany(
                x => x.Value.Errors,
                (state, error) => $"{error.ErrorMessage}</br>"
            ));
        }
    }
}
