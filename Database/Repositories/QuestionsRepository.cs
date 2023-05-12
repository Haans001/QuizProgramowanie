using Microsoft.EntityFrameworkCore;
using QuizPOG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database
{
    public class QuestionsRepository
    {
        public static void AddQuestion(Question question)
        {

            DatabaseLocator.QuizDBContext.Questions.Add(question);
            DatabaseLocator.QuizDBContext.SaveChanges();

        }

        public static List<Question> GetQuestions()
        {


            return DatabaseLocator.QuizDBContext.Questions.Include(q => q.Answers).ToList();
        }
    }

    

}
