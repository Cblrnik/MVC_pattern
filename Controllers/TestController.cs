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
                    if (string.IsNullOrEmpty(answers[j].textOfAnswer) || string.IsNullOrWhiteSpace(answers[j].textOfAnswer))
                    {
                        answers.Remove(answers[j]);
                        db.Answers.Remove(answers[j]);
                        db.SaveChanges();
                    } 
                    else if (answers[j].idQuestion == questions[i].Id)
                    {
                        questions[i].answers.Add(answers[j]);
                    }
                }

                db.SaveChanges();
            }
        }
        
        [HttpPost]
        public IActionResult ChangeQuestion(int admin, int questionId, int numberOfQuestion, string textOfQuestion)
        {
            Question que = db.Question.Where(x => x.Id == questionId).FirstOrDefault();
            que.numberOfQuestion = numberOfQuestion;
            que.textOfQuestion = textOfQuestion;
            db.SaveChanges();
            return RedirectToAction("EditQuest", "Home", new { admin = admin, Id = questionId });
        }

        [HttpGet]
        public IActionResult ChangeAnswers(int admin, int questionId, List<string> textOfAnswers)
        {
            Answer[] answers = db.Answers.Where(x => x.idQuestion == questionId).Select(x => x).ToArray();
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i].textOfAnswer = textOfAnswers[i];
            }

            db.SaveChanges();
            return RedirectToAction("AdminPanel", "Home", new { admin = admin});
        }


        public IActionResult OperationWithTests()
        {
            return View();
        }

        public IActionResult Test()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].answers is null || questions[i].answers.Count < 2 || string.IsNullOrEmpty(questions[i].textOfQuestion) || string.IsNullOrWhiteSpace(questions[i].textOfQuestion))
                {
                    db.Question.Remove(questions[i]);
                    db.SaveChanges();
                    questions.Remove(questions[i]);
                }
            }

            Random r = new Random();
            int index = r.Next(0, questions.Count);
            return View(questions[index]);
        }

        public IActionResult CreateQuestion()
        {
            ViewBag.Id = questions[^1].Id + 1;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAnswer(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
            ViewBag.CanExit = true;
            ViewBag.Id = answer.idQuestion;
            ViewBag.Message = questions.Find(x => x.numberOfQuestion == answer.idQuestion).textOfQuestion;
            return View();
        }

        [HttpGet]
        public IActionResult CreateAnswer(Question question)
        {
            ViewBag.CanExit = false;
            if (string.IsNullOrEmpty(question.textOfQuestion) || string.IsNullOrWhiteSpace(question.textOfQuestion))
            {
                return RedirectToAction("CreateQuestion", "Test");
            }
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
