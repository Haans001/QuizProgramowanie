using Microsoft.EntityFrameworkCore.Storage;
using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.Store;
using QuizProgramowanie.Database;
using QuizProgramowanie.ViewModel;
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

            Questions = new ObservableCollection<QuestionListItemViewModel>();


            foreach (Question q in QuestionsRepository.GetQuestions())
            {
                Questions.Add(new QuestionListItemViewModel(q, this));
            }

            this._navigationStore = navigationStore;

            this.OpenAddQuestionWindowCommand = new RelayCommand(OpenAddQuestionWindow);
            this.NavigateToQuizListCommand = new RelayCommand(NavigateToQuizList);
        }

        private void OpenAddQuestionWindow()
        {
            this.AddQuestionWindow = new QuestionFormWindow()
            {
                DataContext = new AddQuestionFormViewModel(this)
            };
            AddQuestionWindow.ShowDialog();
        }

        private void NavigateToQuizList()
        {
            this._navigationStore.CurrentViewModel = new QuizListViewModel(this._navigationStore);
        }

        public void AddQuestion(Question q)
        {
            QuestionsRepository.AddQuestion(q);
            this.Questions.Add(new QuestionListItemViewModel(q, this));
            AddQuestionWindow.Close();
        }

        public void EditQuestion(Question q, Guid id)
        {
            var found = this.Questions.FirstOrDefault(q => q.Question.Id == id);
            int i = this.Questions.IndexOf(found);
            this.Questions[i] = new QuestionListItemViewModel(q, this);
            QuestionsRepository.UpdateQuestion(q);
        }

    }
}
