using Microsoft.EntityFrameworkCore;
using QuizPOG.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static void UpdateQuestion(Question question)
        {

            var entity = DatabaseLocator.QuizDBContext.Questions.SingleOrDefault(q => q.Id == question.Id);

            if (entity != null)
            {
                entity.Content = question.Content;

                // TODO: HUJ WIE OCB
                //foreach (var answer in entity.Answers.ToList())
                //{
                //    if (!question.Answers.Any(a => a.Id == answer.Id))
                //        DatabaseLocator.QuizDBContext.Set<Answer>().Remove(answer);
                //}


                //foreach (var answer in question.Answers)
                //{
                //    var existingAnswer = entity.Answers
                //        .Where(c => c.Id == answer.Id)
                //        .SingleOrDefault();


                //    if (existingAnswer != null)
                //        DatabaseLocator.QuizDBContext.Entry(existingAnswer).CurrentValues.SetValues(answer);
                //    else
                //    {
                //        var newChild = new Answer
                //        {
                //            Content = answer.Content,
                //            IsCorrect = answer.IsCorrect,
                //        };
                //        entity.Answers.Add(newChild);
                //    }
                //}


                DatabaseLocator.QuizDBContext.SaveChanges();
            }
        }

        public static List<Question> GetQuestions()
        {
            return DatabaseLocator.QuizDBContext.Questions.Include(q => q.Answers).ToList();
        }
    }

    

}
