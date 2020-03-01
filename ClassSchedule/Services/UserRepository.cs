using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public class UserRepository: IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsersAsync(UserDtoParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
