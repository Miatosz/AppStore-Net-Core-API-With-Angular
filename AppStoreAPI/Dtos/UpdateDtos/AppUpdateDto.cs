using System.ComponentModel.DataAnnotations;
using AppStoreAPI.Models;

namespace AppStoreAPI.Dtos.UpdateDtos
{
    public class AppUpdateDto
    {
                
        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public int PlatformId { get; set; }

        public Platform Platform { get; set; }

        [Required]
        public int AgeClassificationId { get; set; }        
        
        public AgeClassification AgeClassification { get; set; }
    }
}