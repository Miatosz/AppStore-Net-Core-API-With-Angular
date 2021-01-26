using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Models;

namespace AppStoreAPI.Repositories
{
    public interface IUserRepo
    {
        IEnumerable<User> Users {get;}
        Task SaveUser(User user);
        Task<User> DeleteUser(int id);
        Task UpdateUser(User user);
    }
}