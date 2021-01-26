using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Repositories
{
    public class UserRepo : IUserRepo
    {
        private AppStoreDbContext _context;

        public UserRepo(AppStoreDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<User> Users => _context.Users;

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task SaveUser(User user)
        {
            if (user.Id == 0)
            {
                await _context.AddAsync(user);
            }
            else
            {
                var newUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);

                if (newUser != null)
                {
                    newUser.Name = user.Name;
                    newUser.Email = user.Email;
                    newUser.Password = user.Password;
                    newUser.Apps = user.Apps;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}