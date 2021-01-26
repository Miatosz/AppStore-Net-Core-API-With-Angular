using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Models;

namespace AppStoreAPI.Repositories
{
    public interface IAppRepo
    {
        IEnumerable<App> Apps {get;}
        Task SaveApp(App app);
        Task<App> DeleteApp(int id);
        Task UpdateApp(App app);
    }
}