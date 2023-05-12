using QuizPOG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.ViewModel
{
    public class QuestionListItemViewModel
    {
        public Question Question;

        public string QuestionContent => Question.Content;

        public string Content => Question.Content;
        public QuestionListItemViewModel(Question q) { 
            this.Question = q;
        }
    }
}
