using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    public class QuizListItemViewModel
    {
        public string Title;
        public string QuizTitle => Title;

        private readonly NavigationStore _navigationStore;
        public ICommand NavigateToQuestListCommand { get; set; }

        public QuizListItemViewModel(string title, NavigationStore navigationStore)
        {
            this.Title = title;
            _navigationStore = navigationStore;
            NavigateToQuestListCommand = new RelayCommand(NavigateToQuestList);
        }

        private void NavigateToQuestList()
        {
            _navigationStore.CurrentViewModel = new QuestionListViewModel(_navigationStore);
        }
    }
}
