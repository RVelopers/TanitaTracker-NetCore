using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_NetCore.ViewModels;

namespace Web_NetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome to Tanita Tracker";
            ViewData["Message"] = "It is an application to work alone with the Omron Body Composition Monitor and Scale (HBF-514C) that allows you to register user, add multiple body scan to each individual user and create reports based those data points.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
