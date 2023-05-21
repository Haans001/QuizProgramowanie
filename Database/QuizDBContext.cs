using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
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
        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Answer> Answers { get; set; }

        private readonly IEncryptionProvider _encryptionProvider;

        public QuizDBContext()
        {
            this._encryptionProvider = new GenerateEncryptionProvider("w!z%C*F-JaNdRgUk");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=QuizProg.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._encryptionProvider);
            base.OnModelCreating(modelBuilder);
        }

    }
}
