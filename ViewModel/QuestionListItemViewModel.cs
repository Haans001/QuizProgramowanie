using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizProgramowanie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    public class QuestionListItemViewModel
    {
        private Window EditQuestionWindow;

        private readonly QuestionListViewModel _questionListViewModel;

        public Question Question;

        public string QuestionContent => Question.Content;

        public ICommand EditCommand { get; set; }

        public string Content => Question.Content;
        public QuestionListItemViewModel(Question q, QuestionListViewModel questionListViewModel) { 
            this.Question = q;
            _questionListViewModel = questionListViewModel;
            this.EditCommand = new RelayCommand(OpenEditQuestionWindow);
        }

        private void OpenEditQuestionWindow()
        {
            this.EditQuestionWindow = new QuestionFormWindow()
            {
                DataContext = new EditQuestionFormViewModel(_questionListViewModel, Question)
            };
            EditQuestionWindow.ShowDialog();
        }

    }
}
