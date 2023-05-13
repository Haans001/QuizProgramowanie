using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{

    public class QuestionListViewModel: BaseViewModel
    {
        private Window AddQuestionWindow;
        public ObservableCollection<QuestionListItemViewModel> Questions { get; set; }

        private readonly NavigationStore _navigationStore;

        public ICommand OpenAddQuestionWindowCommand { get; set; }
        public ICommand NavigateToQuizListCommand { get; set; }

        public QuestionListViewModel(NavigationStore navigationStore)
        {

            Questions = new ObservableCollection<QuestionListItemViewModel>
            {
                new QuestionListItemViewModel(new Question("Dokąd nocą tupta jeż?",
                    new Answer("Do dupy", false),
                    new Answer("Do domu", true),
                    new Answer("Pod koła", true),
                    new Answer("Na dupy", false))
                ),

               new QuestionListItemViewModel(new Question("Co robi Jan?",
                   new Answer("Pije", false),
                   new Answer("Je", true),
                   new Answer("Uczy się", true),
                   new Answer("Gra", false))
               )
            };

            this._navigationStore = navigationStore;

            this.OpenAddQuestionWindowCommand = new RelayCommand(OpenAddQuestionWindow);
            this.NavigateToQuizListCommand = new RelayCommand(NavigateToQuizList);
        }

        private void OpenAddQuestionWindow()
        {
            this.AddQuestionWindow = new AddQuestionWindow()
            {
                DataContext = new QuestionFormViewModel(this)
            };
            AddQuestionWindow.ShowDialog();
        }

        private void NavigateToQuizList()
        {
            this._navigationStore.CurrentViewModel = new QuizListViewModel(this._navigationStore);
        }

        public void AddQuestion(Question q)
        {
            this.Questions.Add(new QuestionListItemViewModel(q));
            AddQuestionWindow.Close();
        }

    }
}
