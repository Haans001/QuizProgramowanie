using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Model
{
    public class Answer
    {

        public Guid Id { get; set; }

        [EncryptColumn]
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}
