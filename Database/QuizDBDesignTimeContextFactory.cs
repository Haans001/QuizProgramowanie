using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database
{
    class QuizDBDesignTimeContextFactory : IDesignTimeDbContextFactory<QuizDBContext>
    {
        public QuizDBContext CreateDbContext(string[] args = null)
        {
            return new QuizDBContext();
        }
    }
}
