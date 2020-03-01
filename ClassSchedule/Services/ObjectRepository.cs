using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public class ObjectRepository: IObjectRepository<User>
    {
        public async Task<IEnumerable<User>> GetAllAsync(object parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(Guid id, User model)
        {
            throw new NotImplementedException();
        }

        public void Update(User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(User model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
