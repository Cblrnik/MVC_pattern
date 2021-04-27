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
        List<Question> questions;

        public TestController(TestContext context)
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

        public IActionResult OperationWithTests()
        {
            return View();
        }

        public IActionResult Test()
        {
            Random r = new Random();
            int index = r.Next(0, questions.Count);
            return View(questions[index]);
        }

        public IActionResult CreateQuestion()
        {
            ViewBag.Id = questions.Count;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAnswer(Answer answer)
        {
            ViewBag.CanExit = true;
            ViewBag.Id = questions.Count;
            ViewBag.Message = questions.Find(x => x.numberOfQuestion == questions.Count).textOfQuestion;
            db.Answers.Add(answer);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult CreateAnswer(Question question)
        {
            ViewBag.CanExit = false;
            db.Question.Add(question);
            db.SaveChanges();
            ViewBag.Id = question.numberOfQuestion;
            ViewBag.Message = question.textOfQuestion;
            return View();
        }

        [HttpPost]
        public IActionResult Result(Сortege cor)
        {

            if (cor.isCorrect)
            {
                ViewBag.isPassed = true;
                ViewBag.Message =  "Ваш ответ на вопроc верен";
            }
            else
            {
                Question q = questions.Find(x => x.Id == cor.idOfQuestion);

                for (int i = 0; i < q.answers.Count; i++)
                {
                    if (q.answers[i].isCorrect)
                    {
                        ViewBag.isPassed = false;
                        ViewBag.Message = "Ваш ответ не верен.";
                        ViewBag.CorrectMessage = "Правильный ответ: " + q.answers[i].textOfAnswer;
                    }
                }
            }

            return View();
        }
    }
}
