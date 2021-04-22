using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class TestController : Controller
    {
        MobileContext db;
        public TestController(MobileContext context)
        {
            db = context;
        }

        public IActionResult OperationWithTests()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
