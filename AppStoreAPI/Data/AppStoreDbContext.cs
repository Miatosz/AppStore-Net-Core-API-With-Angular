using AppStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Data
{
    public class AppStoreDbContext : DbContext
    {
        public AppStoreDbContext()
        {
        }

        public AppStoreDbContext(DbContextOptions<AppStoreDbContext> options) : base(options) {}

        public DbSet<AgeClassification> AgeClassifications {get; set;}
        public DbSet<App> Apps {get; set;}
        public DbSet<Developer> Developers {get; set;}
        public DbSet<Platform> Platforms {get; set;}
        public DbSet<User> Users {get; set;}
    }
}