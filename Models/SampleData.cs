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
                        textOfQuestion = "Является ли автомобиль с числом мест для сидения равным 10 (считая место водителя) автобусом?",
                        numberOfQuestion = 1,
                        chapter = "1",
                        answers = new List<Answer>()
                    },
                    new Question
                    {
                        textOfQuestion = "Какой из приведенных составов транспортных средств не соответствует термину \"автопоезд\"?",
                        numberOfQuestion = 2,
                        chapter = "1",
                        answers = new List<Answer>()
                    },
                    new Question
                    {
                        textOfQuestion = "В каких случаях вы обязаны подавать сигналы световыми указателями поворотов соответствующего направления?",
                        numberOfQuestion = 3,
                        chapter = "9",
                        answers = new List<Answer>()
                    },
                    new Question
                    {
                        textOfQuestion = "В каком из перечисленных случаев водитель не обязан подавть сигнал световыми указателями поворота соответствующего направления?",
                        numberOfQuestion = 4,
                        chapter = "9",
                        answers = new List<Answer>()
                    },
                    new Question
                    {
                        textOfQuestion = "Обязаны ли Вы подавать сигналы световыми указателями поворота перед началом движения, поворотом налево или направо, разворотом и остановкой на территории автостоянки или автозаправочной станции?",
                        numberOfQuestion = 5,
                        chapter = "9",
                        answers = new List<Answer>()
                    },
                    new Question
                    {
                        textOfQuestion = "Обязаны ли водители исполнять сигналы регулировщика, если они противоречат сигналам светофора?",
                        numberOfQuestion = 6,
                        chapter = "7",
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
                        textOfAnswer = "Не является",
                        isCorrect = false,
                        idQuestion = 1
                    },
                    new Answer
                    {
                        textOfAnswer = "Является",
                        isCorrect = true,
                        idQuestion = 1
                    },
                    new Answer
                    {
                        textOfAnswer = "Колесный трактор, буксирующий прицеп",
                        isCorrect = false,
                        idQuestion = 2
                    },
                    new Answer
                    {
                        textOfAnswer = "Седельный тягач, буксирующий полуприцеп",
                        isCorrect = false,
                        idQuestion = 2
                    },
                    new Answer
                    {
                        textOfAnswer = "Велосипед, буксирующий велосипедный прицеп промышленного производства",
                        isCorrect = true,
                        idQuestion = 2
                    },
                    new Answer
                    {
                        textOfAnswer = "Легковой автомобиль, буксирующий прицеп",
                        isCorrect = false,
                        idQuestion = 2
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед приближением к зоне остановки трамвая",
                        isCorrect = false,
                        idQuestion = 3
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед резким торможением",
                        isCorrect = false,
                        idQuestion = 3
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед началом движения",
                        isCorrect = true,
                        idQuestion = 3
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед поворотом дороги",
                        isCorrect = false,
                        idQuestion = 3
                    },
                    new Answer
                    {
                        textOfAnswer = "Во всех перечисленных случаях",
                        isCorrect = false,
                        idQuestion = 3
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед разворотом",
                        isCorrect = false,
                        idQuestion = 4
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед остановкой",
                        isCorrect = false,
                        idQuestion = 4
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед поворотом дороги",
                        isCorrect = true,
                        idQuestion = 4
                    },
                    new Answer
                    {
                        textOfAnswer = "Перед началом движения",
                        isCorrect = false,
                        idQuestion = 4
                    },
                    new Answer
                    {
                        textOfAnswer = "Обязаны",
                        isCorrect = true,
                        idQuestion = 5
                    },
                    new Answer
                    {
                        textOfAnswer = "Не обязаны",
                        isCorrect = false,
                        idQuestion = 5
                    },
                    new Answer
                    {
                        textOfAnswer = "Обязаны, но только при наличии в непосредственной близости других транспортных средств",
                        isCorrect = false,
                        idQuestion = 5
                    },
                    new Answer
                    {
                        textOfAnswer = "Обязаны",
                        isCorrect = true,
                        idQuestion = 6
                    },
                    new Answer
                    {
                        textOfAnswer = "Не обязаны",
                        isCorrect = true,
                        idQuestion = 6
                    },
                    new Answer
                    {
                        textOfAnswer = "По своему усмотрению",
                        isCorrect = false,
                        idQuestion = 6
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
