using Microsoft.EntityFrameworkCore;
using QuizPOG;
using QuizProgramowanie.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database.Repositories
{
    public class QuizzesRepository
    {
        public static void AddQuiz(Quiz quiz)
        {
            DatabaseLocator.QuizDBContext.Quizzes.Add(quiz);
            DatabaseLocator.QuizDBContext.SaveChanges();
        }

        public static List<Quiz> GetAllQuizzes()
        {
            return DatabaseLocator.QuizDBContext.Quizzes.ToList();
        }
    }
}
