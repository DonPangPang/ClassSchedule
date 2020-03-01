using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync(StudentDtoParameters parameters);
        Task<Student> GetStudentAsync(Guid classId, Guid studentId);
        void AddStudent(Guid classId, Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);

        Task<bool> SaveAsync();
    }
}
