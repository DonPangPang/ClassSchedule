using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Data
{
    public class ClassScheduleDbContext: DbContext
    {
        public ClassScheduleDbContext(DbContextOptions<ClassScheduleDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(key => key.UserName);
            modelBuilder.Entity<User>()
                .Property(x => x.UserName).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>()
                .Property(x => x.Password).HasMaxLength(50);

            modelBuilder.Entity<Class>()
                .Property(x => x.Introduction).HasMaxLength(200);
            modelBuilder.Entity<Class>()
                .Property(x => x.ClassName).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(x => x.StudentName).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Course>()
                .Property(x => x.CourseName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Course>()
                .Property(x => x.TeacherName).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Student>()
                .HasOne(x => x.Class)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserName = "admin",
                        Password = "123456",
                        StudentId = Guid.Parse("b4aab9f4-c743-4fc5-a09e-aa172fc318be"),
                        ClassId = Guid.Parse("1b7b249e-658e-4ce5-a012-6277060e1a97")
                    },
                    new User
                    {
                        UserName = "test1",
                        Password = "test1",
                        StudentId = Guid.Parse("57700e3b-ea69-48a4-90cf-6e5bfc9bec6a"),
                        ClassId = Guid.Parse("1bda4fd2-b11e-4934-8f40-3118a630b854")
                    },
                    new User
                    {
                        UserName = "test2",
                        Password = "test2",
                        StudentId = Guid.Parse("79b8da71-e41d-4210-b78b-89e415a65b19"),
                        ClassId = Guid.Parse("83b6fc4b-c619-478c-928c-ca5a9c2f728c")
                    });
            modelBuilder.Entity<Class>()
                .HasData(
                    new Class
                    {
                        ClassId = Guid.Parse("1b7b249e-658e-4ce5-a012-6277060e1a97"),
                        ClassName = "Class1",
                        Introduction = "This is Class 1."
                    },
                    new Class
                    {
                        ClassId = Guid.Parse("1bda4fd2-b11e-4934-8f40-3118a630b854"),
                        ClassName = "Class2",
                        Introduction = "This is Class 2."
                    },
                    new Class
                    {
                        ClassId = Guid.Parse("83b6fc4b-c619-478c-928c-ca5a9c2f728c"),
                        ClassName = "Class3",
                        Introduction = "This is Class 3."
                    }
                );
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student
                    {
                        StudentId = Guid.Parse("b4aab9f4-c743-4fc5-a09e-aa172fc318be"),
                        ClassId = Guid.Parse("1b7b249e-658e-4ce5-a012-6277060e1a97"),
                        StudentName = "A Student"
                    },
                    new Student
                    {
                        StudentId = Guid.Parse("57700e3b-ea69-48a4-90cf-6e5bfc9bec6a"),
                        ClassId = Guid.Parse("1bda4fd2-b11e-4934-8f40-3118a630b854"),
                        StudentName = "B Student"
                    },
                    new Student
                    {
                        StudentId = Guid.Parse("79b8da71-e41d-4210-b78b-89e415a65b19"),
                        ClassId = Guid.Parse("83b6fc4b-c619-478c-928c-ca5a9c2f728c"),
                        StudentName = "C Student"
                    }
                );
            modelBuilder.Entity<Course>()
                .HasData(
                    new Course
                    {
                        CourseId = Guid.Parse("0b1e1cb4-6ce1-498f-a944-32afd9217f5b"),
                        StudentId = Guid.Parse("b4aab9f4-c743-4fc5-a09e-aa172fc318be"),
                        CourseName = "Course A",
                        WeekDay = WeekDay.Friday,
                        Lesson = Lesson.One,
                        BeginWeek = 1,
                        EndWeek = 8,
                        TeacherName = "Teacher A",
                        SingleOrDouble = SingleOrDouble.Single
                    },
                    new Course
                    {
                        CourseId = Guid.Parse("16ae1317-603d-4e42-aa83-87a17cec2b00"),
                        StudentId = Guid.Parse("b4aab9f4-c743-4fc5-a09e-aa172fc318be"),
                        CourseName = "Course B",
                        WeekDay = WeekDay.Friday,
                        Lesson = Lesson.One,
                        BeginWeek = 1,
                        EndWeek = 8,
                        TeacherName = "Teacher B",
                        SingleOrDouble = SingleOrDouble.Single
                    },
                    new Course
                    {
                        CourseId = Guid.Parse("bf370188-1110-4794-85ae-19af49d1a2ac"),
                        StudentId = Guid.Parse("b4aab9f4-c743-4fc5-a09e-aa172fc318be"),
                        CourseName = "Course C",
                        WeekDay = WeekDay.Friday,
                        Lesson = Lesson.One,
                        BeginWeek = 1,
                        EndWeek = 8,
                        TeacherName = "Teacher C",
                        SingleOrDouble = SingleOrDouble.Single
                    },
                    new Course
                    {
                        CourseId = Guid.Parse("5334fc19-f39d-4b5e-87a2-125deb9483ea"),
                        StudentId = Guid.Parse("b4aab9f4-c743-4fc5-a09e-aa172fc318be"),
                        CourseName = "Course D",
                        WeekDay = WeekDay.Friday,
                        Lesson = Lesson.One,
                        BeginWeek = 1,
                        EndWeek = 8,
                        TeacherName = "Teacher D",
                        SingleOrDouble = SingleOrDouble.Single
                    }
                );
            // Add-Migration InitialMigration
        }
    }
}
