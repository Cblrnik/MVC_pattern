using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string textOfAnswer { get; set; }
        public bool isCorrect { get; set; }
        public int idQuestion { get; set; }
    }
}
