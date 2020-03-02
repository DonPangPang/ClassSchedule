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
    public class UserRepository: IUserRepository
    {
        private readonly ClassScheduleDbContext _context;

        public UserRepository(ClassScheduleDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<User>> GetUsersAsync(UserDtoParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _context.Users as IQueryable<User>;

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = parameters.Name.Trim();
                queryExpression = queryExpression.Where(x => x.UserName == parameters.Name);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                parameters.SearchTerm = parameters.SearchTerm.Trim();
                queryExpression = queryExpression.Where(x => x.UserName.Contains(parameters.SearchTerm));
            }

            queryExpression = queryExpression.Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize);

            return await queryExpression.ToListAsync();
        }

        public async Task<User> GetUserAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return await _context.Users
                .FirstOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (user.StudentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(user.StudentId));
            }

            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        public async Task<bool> UserExistsAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return await _context.Users.AnyAsync(x => x.UserName.Equals(username) &&
                                                      x.Password.Equals(password));
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
