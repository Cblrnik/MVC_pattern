using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class HomeController : Controller
    {
        TestContext db;
        List<Question> questions;
        public HomeController(TestContext context)
        {
            this.db = context;
            this.questions = db.Question.ToList();
            List<Answer> answers = db.Answers.ToList();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].answers is null)
                {
                    questions[i].answers = new List<Answer>();
                }

                questions[i].answers.Clear();

                for (int j = 0; j < answers.Count; j++)
                {
                    if (answers[j].idQuestion == questions[i].numberOfQuestion)
                    {
                        questions[i].answers.Add(answers[j]);
                    }
                }

                db.SaveChanges();
            }
        }
        
        public IActionResult DeleteQuestion(int admin, int id)
        {
            db.Question.Remove(questions.Where(x=>x.Id == id).FirstOrDefault());
            db.Answers.RemoveRange(db.Answers.Where(x=>x.idQuestion == id));
            db.SaveChanges();
            return RedirectToAction("AdminPanel", "Home", new { admin = admin });
        }
        public IActionResult EditQuestion(int admin, int id)
        {
            return RedirectToAction("EditQuest", "Home", new { admin = admin, Id = id });
        }

        public IActionResult EditQuest(int admin, int Id)
        {
            Administrator ad = db.Administrators.Where(x => x.Id == admin).First();
            ViewBag.Name = ad.Name;
            ViewBag.Id = admin;
            ViewBag.IdOfQuestion = Id;
            return View(questions.Where(x=>x.Id == Id).FirstOrDefault());
        }

        public IActionResult Auth()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Auth(string login, string pass)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                ViewBag.WrongAnswer = "Логин или пароль не верны";

                return View();
            }
            else
            {
                if (IsValid(login, pass, out Administrator admin))
                {
                    return RedirectToAction("AdminPanel", "Home", new { admin = admin.Id });
                }
                ViewBag.WrongAnswer = "Логин или пароль не верны";

                return View();
            }
        }

        public bool IsValid(string login, string password, out Administrator administrator)
        {
            List<Administrator> admins = db.Administrators.Where(x => x.Login == login).Select(x=>x).ToList();
            foreach (var admin in admins)
            {
                if (admin.Login == login && admin.Password == password)
                {
                    administrator = admin;
                    return true;
                }
            }

            administrator = null;
            return false;
        }

        public IActionResult AdminPanel(int admin)
        {
            Administrator ad = db.Administrators.Where(x=>x.Id == admin).First();
            ViewBag.Name = ad.Name;
            ViewBag.Id = admin;
            return View(questions);
        }

        public IActionResult StartPage() {
            return View(); 
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
