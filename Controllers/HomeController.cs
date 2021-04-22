using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MVC1.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult StartPage() {
            return View(); 
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
