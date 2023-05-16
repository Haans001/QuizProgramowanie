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
            this.SubmitFormCommand = new RelayCommand((p)=> { Submit(); }, p=> CanSubmit());
        }

        private void Submit()
        {
            this._questionListViewMode.AddQuestion(this.convertFormValuesToQuestion());
        }

        private bool CanSubmit()
        {
            if (this.Quest == "" || this.Ans1 == "" || this.Ans2 == ""
                || this.Ans3 == "" || this.Ans4 == "") return false;

            if(this.Chk1 == false && this.Chk2 == false && this.Chk3 == false
                && this.Chk4 == false) return false;

            return true;
        }
    }
}
