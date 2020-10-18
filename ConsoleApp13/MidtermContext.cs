using ConsoleApp13.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class MidtermContext : DbContext
    {
        public MidtermContext()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GCBVPOP;Database=Midterm;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });
            builder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);
            builder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            builder.Entity<Student>().HasData(
                new Student { Id = 1, FullName = "Tom Malaki" },
                new Student { Id = 5, FullName = "Nanuka Gomareli" },
                new Student { Id = 2, FullName = "Niko Nagervadze" },
                new Student { Id = 3, FullName = "Sandro Begiashvili" },
                new Student { Id = 4, FullName = "Neo Reeves" });

            builder.Entity<Subject>().HasData(
                new Subject { Id = 1, SubjectName = "Maths" },
                new Subject { Id = 5, SubjectName = "Biology" },
                new Subject { Id = 2, SubjectName = "Chemistry" },
                new Subject { Id = 3, SubjectName = "Physics" },
                new Subject { Id = 4, SubjectName = "Art" });

        }
    }
}
