using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Question question { get; set; }
        public bool answer1 {get;set;}
    }
}
