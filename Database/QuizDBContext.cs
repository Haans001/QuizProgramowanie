using Microsoft.EntityFrameworkCore;
using QuizPOG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database
{
    class QuizDBContext : DbContext
    {

        public DbSet<Question> Questions { get; set; }
        public QuizDBContext() : base(new DbContextOptionsBuilder().UseSqlite("Data Source=QuizProg.db").Options)
        {
        }

    }
}
