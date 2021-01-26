using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Models;

namespace AppStoreAPI.Repositories
{
    public interface IDeveloperRepo
    {
        IEnumerable<Developer> Developers {get;}
        Task SaveDeveloper(Developer developer);
        Task<Developer> DeleteDeveloper(int id);
        Task UpdateDeveloper(Developer developer);
    }
}