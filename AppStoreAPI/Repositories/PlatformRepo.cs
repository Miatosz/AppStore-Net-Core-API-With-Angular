using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Repositories
{
    public class PlatformRepo : IPlatformRepo
    {
        private AppStoreDbContext _context;

        public PlatformRepo(AppStoreDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Platform> Platforms => _context.Platforms;

        public async Task<Platform> DeletePlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform != null)
            {
                _context.Remove(platform);
                await _context.SaveChangesAsync();
            }
            return platform;
        }

        public async Task SavePlatform(Platform platform)
        {
            if (platform.Id == 0)
            {
                await _context.AddAsync(platform);
            }
            else
            {
                var newPlatform = await _context.Platforms.FirstOrDefaultAsync(c => c.Id == platform.Id);

                if (newPlatform != null)
                {
                    newPlatform.Name = platform.Name;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}