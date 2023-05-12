using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Model
{
    public class Question
    {

        public Guid Id { get; set; }

        public string Content { get; set; }

        public List<Answer> Answers { get; set; }
     
    }
}
