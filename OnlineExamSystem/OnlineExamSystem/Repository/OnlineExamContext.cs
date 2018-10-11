using OnlineExamSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Repository
{
    public class OnlineExamContext : DbContext
    {
        public OnlineExamContext(): base("name=onexmdbstring") {
          Database.SetInitializer<OnlineExamContext>(new DropCreateDatabaseIfModelChanges<OnlineExamContext>());
           //Database.SetInitializer<OnlineExamContext>(new MigrateDatabaseToLatestVersion<OnlineExamContext, Migrations.Configuration>());
        }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<Answer> answers { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Answer Table
            modelBuilder.Entity<Answer>().ToTable("answer")
               .HasKey(i => i.AnswerId)
               .Property(i => i.AnswerId)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Question Table
            modelBuilder.Entity<Question>()
                .ToTable("question").HasKey(i => i.QuestionId)
                .Property(i => i.QuestionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Q&A PK mapping
            modelBuilder.Entity<Answer>().HasRequired(a => a.Question).WithMany(a => a.Answers).HasForeignKey(a => a.QuestionId).WillCascadeOnDelete();

            modelBuilder.Entity<User>()
               .ToTable("user").HasKey(i => i.UserEmail)
               .Property(i => i.UserEmail).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<TestDetails>()
             .ToTable("testDetails").HasKey(i => i.TestId)
             .Property(i => i.TestId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<TestDetails>().Property(x => x.TestDate).HasColumnType("datetime2");

            modelBuilder.Entity<TestDetails>().HasRequired(a => a.user).WithMany(a => a.TestDetails).HasForeignKey(a => a.UserEmail);

           modelBuilder.Entity<UserAnswerDetails>().HasRequired(a => a.TestDetails).WithMany(a => a.UserAnswers).HasForeignKey(a => a.TestId);

            // .ToTable("userAnswerDetails")
            modelBuilder.Entity<UserAnswerDetails>()
             .ToTable("userAnswerDetails").HasKey(i => i.UADId)
             .Property(i => i.UADId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // modelBuilder.Entity<UserAnswerDetails>().HasRequired(a => a.Question).WithMany(a => a.UserAnswerDetails).HasForeignKey(a => a.QuestionId);
        }

        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<TestDetails> TestDetails { get; set; }
        public System.Data.Entity.DbSet<UserAnswerDetails> UserAnswerDetails { get; set; }
    }


}