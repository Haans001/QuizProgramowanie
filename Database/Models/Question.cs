using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Model
{
    public class Question
    {
        public Question(string content, Answer answer1, Answer answer2, Answer answer3, Answer answer4)
        {
            Content = content;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
        }

        public string Content { get; set; }

        public Answer Answer1 { get; set; }

        public Answer Answer2 { get; set; }

        public Answer Answer3 { get; set; }

        public Answer Answer4 { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( Content + "\n" );
            sb.Append( "a) " + Answer1.Content + "\n" );
            sb.Append("b) " + Answer2.Content + "\n");
            sb.Append("c) " + Answer3.Content + "\n");
            sb.Append("d) " + Answer4.Content + "\n");
            return sb.ToString();
        }
    }
}
