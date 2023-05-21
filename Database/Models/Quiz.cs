using QuizPOG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Model
{
    public class Quiz
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
