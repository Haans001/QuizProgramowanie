using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizProgramowanie.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    public class AddQuestionFormViewModel : QuestionFormBaseViewModel
    {

        private readonly QuestionListViewModel _questionListViewMode;

        public AddQuestionFormViewModel(QuestionListViewModel questionListViewMode)
        {
            this._questionListViewMode = questionListViewMode;
            this.SubmitFormCommand = new RelayCommand(Submit);
        }

        private void Submit()
        {
            this._questionListViewMode.AddQuestion(this.convertFormValuesToQuestion());
        }
    }
}
