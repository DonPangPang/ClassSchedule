using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.Data;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Services
{
    public class CourseRepository: ICourseRepository
    {
        private readonly ClassScheduleDbContext _context;

        public CourseRepository(ClassScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(CourseDtoParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _context.Courses as IQueryable<Course>;

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = parameters.Name.Trim();
                queryExpression = queryExpression.Where(x => x.CourseName == parameters.Name);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                parameters.SearchTerm = parameters.SearchTerm.Trim();
                queryExpression = queryExpression.Where(x => x.CourseName.Contains(parameters.SearchTerm));
            }

            queryExpression = queryExpression.Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize);

            return await queryExpression.ToListAsync();
        }

        public async Task<Course> GetCourseAsync(Guid courseId, Guid studentId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return await _context.Courses
                .Where(x => x.CourseId == courseId && x.StudentId == studentId)
                .FirstOrDefaultAsync();
        }

        public void AddCourse(Guid studentId, Course course)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            course.StudentId = studentId;
            _context.Courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
