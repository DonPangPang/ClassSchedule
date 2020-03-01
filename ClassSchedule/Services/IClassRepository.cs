using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClassesAsync(ClassDtoParameters parameters);
        Task<Class> GetClassAsync(Guid classId);
        void AddCLass(Class _class);
        void UpdateClass(Class _class);
        void DeleteClass(Class _class);
        Task<bool> ClassExitAsync(Guid classId);

        Task<bool> SaveAsync();
    }
}
