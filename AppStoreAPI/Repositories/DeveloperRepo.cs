using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Repositories
{
    public class DeveloperRepo : IDeveloperRepo
    {
        private AppStoreDbContext _context;

        public DeveloperRepo(AppStoreDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Developer> Developers => _context.Developers;

        public async Task<Developer> DeleteDeveloper(int id)
        {
            var dev = await _context.Developers.FindAsync(id);
            if (dev != null)
            {
                _context.Remove(dev);
                await _context.SaveChangesAsync();
            }
            return dev;
        }

        public async Task SaveDeveloper(Developer developer)
        {
            if (developer.Id == 0)
            {
                await _context.AddAsync(developer);
            }
            else
            {
                var dev = await _context.Developers.FirstOrDefaultAsync(c => c.Id == developer.Id);

                if (dev != null)
                {
                    dev.Name = developer.Name;
                    dev.CompanyName = developer.CompanyName;
                    //dev.Apps = developer.Apps;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeveloper(Developer developer) 
        { 
            await _context.SaveChangesAsync(); 
        }
    }
}