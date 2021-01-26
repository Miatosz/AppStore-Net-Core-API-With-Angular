using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Repositories
{
    public class AppRepo : IAppRepo
    {
        private AppStoreDbContext _context;

        public AppRepo(AppStoreDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<App> Apps => _context.Apps;

        public async Task<App> DeleteApp(int id)
        {
            var app = await _context.Apps.FindAsync(id);
            if (app != null)
            {
                _context.Remove(app);
                await _context.SaveChangesAsync();
            }
            return app;
        }

        public async Task SaveApp(App app)
        {
            if (app.Id == 0)
            {
                await _context.AddAsync(app);
            }
            else
            {
                var newApp = await _context.Apps.FirstOrDefaultAsync(c => c.Id == app.Id);

                if (newApp != null)
                {
                    newApp.Name = app.Name;
                    newApp.NumberOfDownloads = app.NumberOfDownloads;
                    newApp.Platform = app.Platform;
                    newApp.PlatformId = app.PlatformId;
                    newApp.AgeClassification = app.AgeClassification;
                    newApp.AgeClassificationId = app.AgeClassificationId;
                    newApp.DateOfLastUpdate = app.DateOfLastUpdate;
                    newApp.DateOfUpload = app.DateOfUpload;
                    newApp.Description = app.Description;
                    newApp.Developer = app.Developer;
                    newApp.DeveloperId = app.DeveloperId;
                    newApp.Price = app.Price;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateApp(App app) 
        { 
            await _context.SaveChangesAsync(); 
        }
    }
}