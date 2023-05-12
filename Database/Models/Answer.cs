using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Model
{
    public class Answer
    {
        public Answer(string content, bool isCorrect)
        {
            Content = content;
            IsCorrect = isCorrect;
        }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}
