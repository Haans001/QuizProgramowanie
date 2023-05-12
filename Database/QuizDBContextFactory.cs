using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProgramowanie.Database
{
    class QuizDBContextFactory
    {

        private readonly DbContextOptions _options;

        public QuizDBContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public QuizDBContext Create()
        {

            return new QuizDBContext(_options);
        }
    }
}
