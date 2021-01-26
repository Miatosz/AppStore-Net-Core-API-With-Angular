using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Models
{
    public class AgeClassification
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}