using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;

namespace ClassSchedule.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync(UserDtoParameters parameters);
        Task<User> GetUserAsync(string username, string password);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        Task<bool> SaveAsync();
    }
}
