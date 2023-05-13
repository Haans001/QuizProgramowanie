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
    public class QuizFormViewModel :BaseViewModel
    {
        private readonly QuizListViewModel _quizListViewModel;

        public ICommand SubmitQuizCommand { get; set; }

        public QuizFormViewModel(QuizListViewModel quizListViewModel)
        {
            _quizListViewModel = quizListViewModel;
            SubmitQuizCommand = new RelayCommand(Submit);
        }

        public string Title { get; set; }

        private void Submit()
        {
            string title = Title;
            _quizListViewModel.AddQuiz(title);
        }
    }
}
