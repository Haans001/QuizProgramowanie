using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Store;
using QuizPOG.Model;
using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace QuizPOG.ViewModel
{
    public class QuizListItemViewModel
    {
        private Window SolveQuizWindow;

        public readonly Quiz Quiz;
        public string Title => Quiz.Title;

        private readonly NavigationStore _navigationStore;

        public ICommand NavigateToQuestListCommand { get; set; }
        public ICommand OpenSolveQuizWindowCommand { get; set; }

        public QuizListItemViewModel(Quiz quiz, NavigationStore navigationStore)
        {
            Quiz = quiz;
            _navigationStore = navigationStore;
            
            NavigateToQuestListCommand = new RelayCommand((p) => { NavigateToQuestList(); });
            OpenSolveQuizWindowCommand = new RelayCommand((p) => OpenSolveQuizWindow(), p => CanOpenSolveQuizWindow());
        }

        private void NavigateToQuestList()
        {
            _navigationStore.CurrentViewModel = new QuestionListViewModel(this._navigationStore, Quiz);
        }

        private void OpenSolveQuizWindow()
        {
            SolveQuizWindow = new SolveQuizWindow()
            {
                DataContext = new SolveQuizViewModel(this, Quiz, 0)
            };

            SolveQuizWindow.ShowDialog();
        }

        private bool CanOpenSolveQuizWindow()
        {
            if (Quiz.Questions.Count == 0)
                return false;

            return true;
        }

        public void EndQuiz(int points, string time)
        {
            MessageBox.Show("Twój wynik to: " + points.ToString() + "/" + Quiz.Questions.Count.ToString() + ". " + time, 
                "Wynik Quizu", MessageBoxButton.OK, MessageBoxImage.Information);

            SolveQuizWindow.Close();
        }
    }
}
