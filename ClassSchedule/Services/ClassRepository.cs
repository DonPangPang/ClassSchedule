using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.Data;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

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

            throw new NotImplementedException();
        }

        public async Task<Class> GetClassAsync(Guid classId)
        {
            throw new NotImplementedException();
        }

        public void AddCLass(Class _class)
        {
            throw new NotImplementedException();
        }

        public void UpdateClass(Class _class)
        {
            throw new NotImplementedException();
        }

        public void DeleteClass(Class _class)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClassExitAsync(Guid classId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
