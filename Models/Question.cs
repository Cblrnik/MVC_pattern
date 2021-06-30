using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int numberOfQuestion { get; set; }
        public string textOfQuestion { get; set; }
        public string chapter { get; set; }
        public List<Answer> answers { get; set; }
    }
}
