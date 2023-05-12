using Microsoft.EntityFrameworkCore;
using QuizProgramowanie.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database
{
    class QuizDBContext : DbContext
    {

        public DbSet<QuestionDTO> Questions { get; set; }
        public QuizDBContext(DbContextOptions options) : base(options)
        {
        }

    }
}
