using Microsoft.EntityFrameworkCore.Storage;
using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.Store;
using QuizProgramowanie.Database;
using QuizProgramowanie.Database.Models;
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

        private readonly Quiz _quiz;

        private readonly NavigationStore _navigationStore;

        public ICommand OpenAddQuestionWindowCommand { get; set; }
        public ICommand NavigateToQuizListCommand { get; set; }

        public QuestionListViewModel(NavigationStore navigationStore, Quiz quiz)
        {

            Questions = new ObservableCollection<QuestionListItemViewModel>();

            this._quiz = quiz;

            if(quiz.Questions != null)
            {
                foreach (Question q in quiz.Questions)
                {
                    Questions.Add(new QuestionListItemViewModel(q, this));
                }
            }

            this._navigationStore = navigationStore;

            this.OpenAddQuestionWindowCommand = new RelayCommand((p)=> { OpenAddQuestionWindow(); });
            this.NavigateToQuizListCommand = new RelayCommand((p) => { NavigateToQuizList(); });
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
            QuestionsRepository.AddQuestion(q, _quiz);
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
