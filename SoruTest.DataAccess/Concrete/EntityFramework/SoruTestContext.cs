using Microsoft.EntityFrameworkCore;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.DataAccess.Concrete.EntityFramework
{
    public class SoruTestContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=SoruTest;Trusted_Connection=True;");
        }


        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
