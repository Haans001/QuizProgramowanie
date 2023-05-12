using QuizPOG.Model;
using QuizProgramowanie.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database.Commands
{
    class AddQuestionCommand
    {
        private readonly QuizDBContextFactory _dbContextFactory;

        public AddQuestionCommand(QuizDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public async Task Execute(Question question)
        {
            using (QuizDBContext context = _dbContextFactory.Create())
            {
                QuestionDTO questionDTO = new()
                {
                    Content = question.Content,
                    Answers = new List<AnswerDTO>()
                {
                    new AnswerDTO()
                    {
                        Content = question.Answer1.Content,
                        IsCorrect =  question.Answer1.IsCorrect,
                    },
                    new AnswerDTO()
                    {
                        Content = question.Answer2.Content,
                        IsCorrect = question.Answer2.IsCorrect,
                    },
                    new AnswerDTO()
                    {
                        Content = question.Answer3.Content,
                        IsCorrect = question.Answer3.IsCorrect,
                    },
                    new AnswerDTO()
                    {
                        Content = question.Answer4.Content,
                        IsCorrect = question.Answer4.IsCorrect,
                    }
            }
                };

                context.Questions.Add(questionDTO);
                await context.SaveChangesAsync();
            }

        }
    }
}
