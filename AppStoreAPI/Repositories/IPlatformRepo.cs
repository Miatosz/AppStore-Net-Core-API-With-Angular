using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Models;

namespace AppStoreAPI.Repositories
{
    public interface IPlatformRepo
    {
        IEnumerable<Platform> Platforms {get;}
        Task SavePlatform(Platform platform);
        Task<Platform> DeletePlatform(int id);
    }
}