using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    public class QuizFormBaseViewModel : BaseViewModel
    {
        private string _quizTitle = String.Empty;

        public ICommand SubmitQuizCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public string Title
        {
            get { return _quizTitle; }
            set
            {
                _quizTitle = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
}
