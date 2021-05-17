using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC1.Models;

namespace MVC1.Models
{
    public class SampleData
    {
        public static void Initialize(TestContext context)
        {
            if (!context.Administrators.Any())
            {
                context.Administrators.Add
                (
                    new Administrator
                    {
                        Name = "Main Admin",
                        Login = "Administrator",
                        Password = "Admin"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Question.Any())
            {
                context.Question.AddRange(
                    new Question
                    {
                        textOfQuestion = "Очень важный вопрос",
                        numberOfQuestion = 1,
                        typeOfQuestion = 1,
                        answers = new List<Answer>()
                    },
                    new Question
                    {
                        textOfQuestion = "Почти очень важный вопрос",
                        numberOfQuestion = 2,
                        typeOfQuestion = 2,
                        answers = new List<Answer>()
                    }
                );
                context.SaveChanges();
            }
            if (!context.Answers.Any())
            {
                context.Answers.AddRange(
                    new Answer
                    {
                        textOfAnswer = "Правильный ответ",
                        isCorrect = true,
                        idQuestion = 1
                    },
                    new Answer
                    {
                        textOfAnswer = "Неправильный ответ",
                        isCorrect = false,
                        idQuestion = 1
                    },
                    new Answer
                    {
                        textOfAnswer = "Правильный ответ",
                        isCorrect = true,
                        idQuestion = 2
                    },
                    new Answer
                    {
                        textOfAnswer = "Неправильный ответ",
                        isCorrect = false,
                        idQuestion = 2
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
