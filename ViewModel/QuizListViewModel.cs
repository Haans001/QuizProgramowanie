using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using QuizProgramowanie.Database.Repositories;
using QuizProgramowanie.Database.Models;
using QuizProgramowanie.Database;

namespace QuizPOG.ViewModel
{
    public class QuizListViewModel : BaseViewModel
    {
        private Window AddQuizWindow;
        public ObservableCollection<QuizListItemViewModel> Quizes { get; set; } = new ObservableCollection<QuizListItemViewModel>();

        private readonly NavigationStore _navigationStore;

        public ICommand OpenAddQuizWindowCommand { get; set; }
        

        public QuizListViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            foreach (Quiz q in QuizzesRepository.GetAllQuizzes())
            {
                Quizes.Add(new QuizListItemViewModel(q, navigationStore));
            }

            OpenAddQuizWindowCommand = new RelayCommand(OpenAddQuestionWindow);
        }

        private void OpenAddQuestionWindow()
        {
            AddQuizWindow = new AddQuizWindow()
            {
                DataContext = new QuizFormViewModel(this)
            };

            AddQuizWindow.ShowDialog();
        }

        public void AddQuiz(string q)
        {
            Quiz quiz = new Quiz()
            {
                Title = q,
                Questions = new List<Question>()
            };
            Quizes.Add(new QuizListItemViewModel(quiz, _navigationStore));
            QuizzesRepository.AddQuiz(quiz);
            AddQuizWindow.Close();
        }
    }
}
