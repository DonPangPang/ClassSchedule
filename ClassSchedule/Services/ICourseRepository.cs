using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync(CourseDtoParameters parameters);
        Task<Course> GetCourseAsync(Guid courseId, Guid studentId);
        void AddCourse(Guid studentId, Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        Task<bool> CourseExitAsync(Guid courseId);

        Task<bool> SaveAsync();
    }
}
