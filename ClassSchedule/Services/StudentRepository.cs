using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.Data;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ClassSchedule.Services
{
    public class StudentRepository: IStudentRepository
    {
        private readonly ClassScheduleDbContext _context;

        public StudentRepository(ClassScheduleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync(StudentDtoParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _context.Students as IQueryable<Student>;

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = parameters.Name.Trim();
                queryExpression = queryExpression.Where(x => x.StudentName == parameters.Name);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                parameters.SearchTerm = parameters.SearchTerm.Trim();
                queryExpression = queryExpression.Where(x => x.StudentName.Contains(parameters.SearchTerm));
            }

            queryExpression = queryExpression.Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize);

            return await queryExpression.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid classId, Guid studentId)
        {
            if (classId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classId));
            }

            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return await _context.Students
                .FirstOrDefaultAsync(x => x.ClassId == classId && x.StudentId == studentId);
        }

        public void AddStudent(Guid classId, Student student)
        {
            if (classId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classId));
            }

            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            student.ClassId = classId;
            _context.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }

        public async Task<bool> StudentExitAsync(Guid studentId)
        {
            if(studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return await _context.Students.AnyAsync(x => x.StudentId == studentId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
