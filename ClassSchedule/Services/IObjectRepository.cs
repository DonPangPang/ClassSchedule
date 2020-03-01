using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Services
{
    public interface IObjectRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(object parameters);
        Task<T> GetAsync(Guid id);
        void Add(Guid id, T model);
        void Update(T model);
        void Delete(T model);

        Task<bool> SaveAsync();
    }
}
