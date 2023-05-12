using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database.DTO
{
    class QuestionDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public ICollection<AnswerDTO> Answers{ get; set; }
    }
}
