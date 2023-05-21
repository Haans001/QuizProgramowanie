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
        public static void AddQuestion(Question question, Quiz q)
        {

            q.Questions.Add(question);

            DatabaseLocator.QuizDBContext.SaveChanges();
        }

        public static List<Question> GetAllQuestions(Quiz quiz)
        {
            return quiz.Questions;
        }

        public static void UpdateQuestion(Question question)
        {

            var entity = DatabaseLocator.QuizDBContext.Questions.SingleOrDefault(q => q.Id == question.Id);

            if (entity != null)
            {
                DatabaseLocator.QuizDBContext.Answers.RemoveRange(entity.Answers);
                entity.Answers = question.Answers;
                entity.Content = question.Content;
            }

            DatabaseLocator.QuizDBContext.SaveChanges();
            }

        public static void DeleteQuestion(Question question)
        {
            var questionToRemove = DatabaseLocator.QuizDBContext.Questions.Include(q => q.Answers)
                                              .FirstOrDefault(q => q.Id == question.Id);

            if (questionToRemove != null)
            {
                DatabaseLocator.QuizDBContext.Answers.RemoveRange(questionToRemove.Answers);
                DatabaseLocator.QuizDBContext.Questions.Remove(questionToRemove);
                DatabaseLocator.QuizDBContext.SaveChanges();
            }
        }
    
    }
    }