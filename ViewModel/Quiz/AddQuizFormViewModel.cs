using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    public class AddQuizFormViewModel : QuizFormBaseViewModel
    {
        private readonly QuizListViewModel _quizListViewModel;

        public AddQuizFormViewModel(QuizListViewModel quizListViewModel)
        {
            _quizListViewModel = quizListViewModel;
            SubmitQuizCommand = new RelayCommand((p) => { Submit(); }, p => CanSubmit());
            ClearCommand = new RelayCommand((p) => { Clear(); });
        }

        private void Submit()
        {
            string title = Title;
            _quizListViewModel.AddQuiz(title);
        }

        private bool CanSubmit()
        {
            if (String.IsNullOrEmpty(Title))
                return false;

            return true;
        }

        private void Clear()
        {
            this.Title = String.Empty;
        }
    }
}
