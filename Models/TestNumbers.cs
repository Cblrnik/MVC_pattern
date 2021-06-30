using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Models
{
    public class TestNumbers
    {
        public int[] IdsOfQuestions { get; set; }
        public Question Question { get; set; }
        public TestNumbers(int[] IdsOfQuestions, Question question)
        {
            this.IdsOfQuestions = IdsOfQuestions;
            this.Question = question;
        }
    }
}
