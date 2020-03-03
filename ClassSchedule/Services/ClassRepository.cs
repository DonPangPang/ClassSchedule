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
    public class ClassRepository: IClassRepository
    {
        private readonly ClassScheduleDbContext _context;

        public ClassRepository(ClassScheduleDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Class>> GetClassesAsync(ClassDtoParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _context.Classes as IQueryable<Class>;

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = parameters.Name.Trim();
                queryExpression = queryExpression.Where(x => x.Name == parameters.Name);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                parameters.SearchTerm = parameters.SearchTerm.Trim();
                queryExpression = queryExpression.Where(x => x.Name.Contains(parameters.SearchTerm));
            }

            queryExpression = queryExpression.Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize);

            return await queryExpression.ToListAsync();
        }

        public async Task<Class> GetClassAsync(Guid classId)
        {
            if(classId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classId));
            }

            return await _context.Classes
                .FirstOrDefaultAsync(x => x.ClassId == classId);
        }

        public void AddCLass(Class _class)
        {
            if (_class != null)
            {
                throw new ArgumentNullException(nameof(_class));
            }

            _class.ClassId = Guid.NewGuid();

            if (_class.Students != null)
            {
                foreach (var student in _class.Students)
                {
                    student.StudentId = Guid.NewGuid();
                }
            }

            _context.Classes.Add(_class);
        }

        public void UpdateClass(Class _class)
        {
            _context.Entry(_class).State = EntityState.Modified;
        }

        public void DeleteClass(Class _class)
        {
            if (_class == null)
            {
                throw new ArgumentNullException(nameof(_class));
            }

            _context.Classes.Remove(_class);
        }

        public async Task<bool> ClassExitAsync(Guid classId)
        {
            if (classId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classId));
            }

            return await _context.Classes.AnyAsync(x => x.ClassId == classId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
