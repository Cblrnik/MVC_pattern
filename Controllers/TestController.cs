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
        TestContext db;

        public TestController(TestContext context)
        {
            this.db = context;
        }

        public IActionResult OperationWithTests()
        {
            return View();
        }

        public IActionResult Test()
        {
            List<Question> questions = new List<Question>();
            questions = db.Question.ToList();
            List<Answer> answers = db.Answers.ToList();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].answers is null)
                {
                    questions[i].answers = new List<Answer>();
                    for (int j = 0; j < answers.Count; j++)
                    {
                        if (answers[j].idQuestion == questions[i].Id)
                        {
                            questions[i].answers.Add(answers[j]);
                        }
                    }
                }
            }

            return View(questions);
        }

        [HttpPost]
        public IActionResult Test(Result result)
        {

            return View();
        }
    }
}
