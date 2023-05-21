using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizPOG.ViewModel
{
    internal class SolveQuizBaseViewModel : BaseViewModel
    {
        private string quest = "";
        private string ans1 = "";
        private string ans2 = "";
        private string ans3 = "";
        private string ans4 = "";
        private bool chk1;
        private bool chk2;
        private bool chk3;
        private bool chk4;
        private string buttonContent = "Następne pytanie";

        public ICommand SolverCommand { get; set; }

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

        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                OnPropertyChanged(nameof(ButtonContent));
            }
        }
    }
}
