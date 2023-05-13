using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.ViewModel
{
    public class QuizListItemViewModel
    {
        public string Title;
        public string QuizTitle => Title;

        public QuizListItemViewModel(string title)
        {
            this.Title = title;
        }
    }
}
