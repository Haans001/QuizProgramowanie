using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizProgramowanie.Database;
using QuizProgramowanie.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ICommand DeleteCommand { get; set; }

        public string Content => Question.Content;
        public QuestionListItemViewModel(Question q, QuestionListViewModel questionListViewModel) { 
            this.Question = q;
            _questionListViewModel = questionListViewModel;
            this.EditCommand = new RelayCommand((p) => { OpenEditQuestionWindow(); });
            this.DeleteCommand = new RelayCommand((p) => { DeleteQuestionCommand(); });
        }

        private void OpenEditQuestionWindow()
        {
            this.EditQuestionWindow = new QuestionFormWindow()
            {
                DataContext = new EditQuestionFormViewModel(_questionListViewModel, Question)
            };
            EditQuestionWindow.ShowDialog();
        }

        private void DeleteQuestionCommand()
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć pytanie?", "Usuń pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var collection = _questionListViewModel.Questions;
                collection.Remove(collection.Where(q => q.Question.Id == this.Question.Id).Single());
               QuestionsRepository.DeleteQuestion(this.Question);
            }
        }

    }
}
