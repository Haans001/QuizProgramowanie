using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.ViewModel
{
    class EditQuestionFormViewModel : QuestionFormBaseViewModel
    {
        private readonly QuestionListViewModel _questionListViewMode;

        private readonly Question _question;

        public EditQuestionFormViewModel(QuestionListViewModel questionListViewMode, Question question)
        {
            this._questionListViewMode = questionListViewMode;
            this._question = question;

            this.Quest = question.Content;
            this.Ans1 = question.Answers[0].Content;
            this.Ans2 = question.Answers[1].Content;
            this.Ans3 = question.Answers[2].Content;
            this.Ans4 = question.Answers[3].Content;

            this.Chk1 = question.Answers[0].IsCorrect;
            this.Chk2 = question.Answers[1].IsCorrect;
            this.Chk3 = question.Answers[2].IsCorrect;
            this.Chk4 = question.Answers[3].IsCorrect;

            this.SubmitFormCommand = new RelayCommand((p) => { Submit(); }, p => CanSubmit());
            this.ClearCommand = new RelayCommand((p) => { Clear(); });
        }

        private void Submit()
        {
            Question q = this.convertFormValuesToQuestion();
            q.Id = _question.Id;
            _questionListViewMode.EditQuestion(q, _question.Id);
        }

        private bool CanSubmit()
        {
            if (String.IsNullOrEmpty(Quest) || String.IsNullOrEmpty(Ans1) || String.IsNullOrEmpty(Ans2)
                || String.IsNullOrEmpty(Ans3) || String.IsNullOrEmpty(Ans4)) 
                    return false;

            if (this.Chk1 == false && this.Chk2 == false && this.Chk3 == false
                && this.Chk4 == false) return false;

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
