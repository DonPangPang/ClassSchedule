using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public class StudentRepository: IStudentRepository
    {
        public async Task<IEnumerable<Student>> GetStudentsAsync(StudentDtoParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentAsync(Guid classId, Guid studentId)
        {
            throw new NotImplementedException();
        }

        public void AddStudent(Guid classId, Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
