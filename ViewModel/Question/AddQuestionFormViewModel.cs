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
            this.ClearCommand = new RelayCommand((p)=> { Clear(); });
        }

        private void Submit()
        {
            this._questionListViewMode.AddQuestion(this.convertFormValuesToQuestion());
        }

        private bool CanSubmit()
        {
            if(String.IsNullOrEmpty(Quest) || String.IsNullOrEmpty(Ans1) || 
                String.IsNullOrEmpty(Ans2) || String.IsNullOrEmpty(Ans3) ||
                String.IsNullOrEmpty(Ans4))
                return false;

            if (Chk1 == false && Chk2 == false && Chk3 == false
                && Chk4 == false) 
                return false;

            return true;
        }

        private void Clear()
        {
            Quest = String.Empty;
            Ans1 = String.Empty;
            Ans2 = String.Empty;
            Ans3 = String.Empty;
            Ans4 = String.Empty;
            Chk1 = false;
            Chk2 = false;
            Chk3 = false;
            Chk4 = false;
        }
    }
}
