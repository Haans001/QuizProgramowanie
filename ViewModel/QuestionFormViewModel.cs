using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
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
    public class QuestionFormViewModel : BaseViewModel
    {
        private string quest;
        private string ans1;
        private string ans2;
        private string ans3;
        private string ans4;
        private bool chk1;
        private bool chk2;
        private bool chk3;
        private bool chk4;

        private readonly QuestionListViewModel _questionListViewMode;

        public ICommand SubmitFormCommand { get; set; }

        public QuestionFormViewModel(QuestionListViewModel questionListViewMode)
        {
            this._questionListViewMode = questionListViewMode;

            this.SubmitFormCommand = new RelayCommand(Submit);
        }

        public string Quest
        {
            get { return quest; }
            set
            {
                quest = value;
                OnPropertyChanged(nameof(Quest));
            }
        }
        public string Ans1
        {
            get { return ans1; }
            set
            {
                ans1 = value;
                OnPropertyChanged(nameof(Ans1));
            }
        }
        public string Ans2 
        {
            get { return ans2; }
            set
            {
                ans2 = value;
                OnPropertyChanged(nameof(Ans2));
            }
        }
        public string Ans3 
        {
            get { return ans3; }
            set
            {
                ans3 = value;
                OnPropertyChanged(nameof(Ans3));
            }
        }
        public string Ans4 
        {
            get { return ans4; }
            set
            {
                ans4 = value;
                OnPropertyChanged(nameof(Ans4));
            }
        }

        public bool Chk1
        {
            get { return chk1; }
            set
            {
                chk1 = value;
                OnPropertyChanged(nameof(Chk1));
            }
        }

        public bool Chk2
        {
            get { return chk2; }
            set
            {
                chk2 = value;
                OnPropertyChanged(nameof(Chk2));
            }
        }

        public bool Chk3
        {
            get { return chk3; }
            set
            {
                chk3 = value;
                OnPropertyChanged(nameof(Chk3));
            }
        }

        public bool Chk4
        {
            get { return chk4; }
            set
            {
                chk4 = value;
                OnPropertyChanged(nameof(Chk4));
            }
        }


        public ICommand EditCommand { get; }
        public ICommand ClearCommand { get; }

        private void Submit()
        {
            Answer answer1 = new Answer(Ans1, Chk1);
            Answer answer2 = new Answer(Ans2, Chk2);
            Answer answer3 = new Answer (Ans3, Chk3);
            Answer answer4 = new Answer (Ans4, Chk4);
            Question question = new Question(Quest, answer1, answer2, answer3, answer4);

            this._questionListViewMode.AddQuestion(question);
        }
    }
}
