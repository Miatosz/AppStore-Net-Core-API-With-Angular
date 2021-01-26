using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Models;

namespace AppStoreAPI.Repositories
{
    public interface IAgeClassificationRepo
    {
        IEnumerable<AgeClassification> AgeClassifications {get;}
        Task SaveAgeClassification(AgeClassification ageClassification);
        Task<AgeClassification> DeleteAgeClassification(int id);
        Task UpdateAgeClassification(AgeClassification ageClassification);
    }
}