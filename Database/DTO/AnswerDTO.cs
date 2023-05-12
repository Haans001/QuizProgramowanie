using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database.DTO
{
   public class AnswerDTO
    {

        public Guid Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}
