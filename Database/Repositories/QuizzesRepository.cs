using Microsoft.EntityFrameworkCore;
using QuizPOG;
using QuizPOG.Model;
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

        public static void UpdateQuiz(Quiz quiz)
        {
            var entity = DatabaseLocator.QuizDBContext.Quizzes.SingleOrDefault(q => q.Id == quiz.Id);
            
            if (entity != null)
                entity.Title = quiz.Title;

            DatabaseLocator.QuizDBContext.SaveChanges();
        }
    }
}
