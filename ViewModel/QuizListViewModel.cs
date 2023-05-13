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
            Quizes.Add(new QuizListItemViewModel(q, _navigationStore));
            AddQuizWindow.Close();
        }
    }
}
