using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public class CourseRepository: ICourseRepository
    {
        public async Task<IEnumerable<Course>> GetCoursesAsync(CourseDtoParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourseAsync(Guid courseId, Guid studentId)
        {
            throw new NotImplementedException();
        }

        public void AddCourse(Guid studentId, Course course)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
