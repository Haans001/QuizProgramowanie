using QuizGenerator.Core.Helpers.Commands;
using QuizPOG.Model;
using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizPOG.ViewModel
{
    class SolveQuizViewModel : SolveQuizBaseViewModel
    {
        private readonly QuizListItemViewModel _quizListItemViewModel;
        private readonly Quiz _quiz;
        private int _questIter;
        private int _points;

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
                _quizListItemViewModel.EndQuiz(_points);
            }
        }
    }
}
