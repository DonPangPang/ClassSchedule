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
                .Property(x => x.UserName).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>()
                .Property(x => x.Password).HasMaxLength(50);

            modelBuilder.Entity<Class>()
                .Property(x => x.Introduction).HasMaxLength(200);
            modelBuilder.Entity<Class>()
                .Property(x => x.Name).IsRequired().HasMaxLength(100);

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
        }
    }
}
