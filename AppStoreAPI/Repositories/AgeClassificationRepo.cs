using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Repositories
{
    public class AgeClassificationRepo : IAgeClassificationRepo
    {
        private AppStoreDbContext _context;

        public AgeClassificationRepo(AppStoreDbContext ctx)
        {
            this._context = ctx;
        }

        public IEnumerable<AgeClassification> AgeClassifications => _context.AgeClassifications;

        public async Task<AgeClassification> DeleteAgeClassification(int id)
        {
            var ac = await _context.AgeClassifications.FindAsync(id);
            if (ac != null)
            {
                _context.Remove(ac);
                await _context.SaveChangesAsync();
            }
            return ac;
        }

        public async Task SaveAgeClassification(AgeClassification ageClassification)
        {
            if (ageClassification.Id == 0)
            {
                await _context.AddAsync(ageClassification);
            }
            else
            {
                var ac = await _context.AgeClassifications.FirstOrDefaultAsync(c => c.Id == ageClassification.Id);

                if (ac != null)
                {
                    ac.Name = ageClassification.Name;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgeClassification(AgeClassification ageClassification)
        {
            await _context.SaveChangesAsync();
        }
    }
}