using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace QuizPOG.ViewModel
{
    class SolveQuizViewModel : SolveQuizBaseViewModel
    {
        private readonly QuizListItemViewModel _quizListItemViewModel;
        private readonly Quiz _quiz;
        private int _questIter;
        private int _points;

        private string _timeCount = "Czas: 00:00";
        private int _seconds = 0;

        private Timer _timer;

        public string TimeCount
        {
            get { return _timeCount; }
            set
            {
                _timeCount = "Czas: " + value;
                OnPropertyChanged(nameof(TimeCount));
            }
        }

        public SolveQuizViewModel(QuizListItemViewModel quizListItemViewModel,Quiz quiz, int questIter)
        {
            _quizListItemViewModel = quizListItemViewModel;
            _quiz = quiz;
            _questIter = questIter;
            _points = 0;

            Quest = _quiz.Questions[questIter].Content;
            Ans1 = _quiz.Questions[questIter].Answers[0].Content;
            Ans2 = _quiz.Questions[questIter].Answers[1].Content;
            Ans3 = _quiz.Questions[questIter].Answers[2].Content;
            Ans4 = _quiz.Questions[questIter].Answers[3].Content;

            if (_questIter < _quiz.Questions.Count - 1)
                ButtonContent = "Następne pytanie";
            else
                ButtonContent = "Zakończ Quiz";

            SolverCommand = new RelayCommand((p) => { Solver(); });


            _timer = new Timer(1000);
            _timer.Elapsed += handleTimeCountUpdate;
            _timer.Start();
        }

        public void handleTimeCountUpdate(object sender, ElapsedEventArgs e)
        {
            _seconds++;
            TimeSpan time = TimeSpan.FromSeconds(_seconds);
            TimeCount = time.ToString("mm\\:ss");

        }

        private void Solver()
        {
            if (Chk1 == _quiz.Questions[_questIter].Answers[0].IsCorrect && Chk2 == _quiz.Questions[_questIter].Answers[1].IsCorrect &&
                    Chk3 == _quiz.Questions[_questIter].Answers[2].IsCorrect && Chk4 == _quiz.Questions[_questIter].Answers[3].IsCorrect)
                _points++;

            if (_questIter < _quiz.Questions.Count - 1)
            {
                _questIter++;

                Quest = _quiz.Questions[_questIter].Content;
                Ans1 = _quiz.Questions[_questIter].Answers[0].Content;
                Ans2 = _quiz.Questions[_questIter].Answers[1].Content;
                Ans3 = _quiz.Questions[_questIter].Answers[2].Content;
                Ans4 = _quiz.Questions[_questIter].Answers[3].Content;
                Chk1 = false; Chk2 = false; Chk3 = false; Chk4 = false;

                if (_questIter == _quiz.Questions.Count - 1)
                    ButtonContent = "Zakończ Quiz";
            }
            else
            {

                _timer.Stop();
                _timer.Dispose();
                _quizListItemViewModel.EndQuiz(_points, _timeCount);

            }
        }
    }
}
