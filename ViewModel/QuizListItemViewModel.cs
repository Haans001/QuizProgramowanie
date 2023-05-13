using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Store;
using QuizProgramowanie.Database.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    public class QuizListItemViewModel
    {
        private readonly Quiz _quiz;
        public string QuizTitle => _quiz.Title;

        private readonly NavigationStore _navigationStore;
        public ICommand NavigateToQuestListCommand { get; set; }

        public QuizListItemViewModel(Quiz quiz, NavigationStore navigationStore)
        {
            this._quiz = quiz;
            _navigationStore = navigationStore;
            NavigateToQuestListCommand = new RelayCommand(NavigateToQuestList);

        }

        private void NavigateToQuestList()
        {
            _navigationStore.CurrentViewModel = new QuestionListViewModel(this._navigationStore, _quiz);
        }
    }
}
