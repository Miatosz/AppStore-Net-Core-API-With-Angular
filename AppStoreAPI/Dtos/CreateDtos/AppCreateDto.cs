using System.ComponentModel.DataAnnotations;
using AppStoreAPI.Models;

namespace AppStoreAPI.Dtos
{
    public class AppCreateDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DateOfUpload { get; set; }

        [Required]
        public string DateOfLastUpdate { get; set; }

        [Required]
        public float Price { get; set; }


        public int NumberOfDownloads { get; set; }

        public int DeveloperId { get; set; }
        
        public Developer Developer { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }

        public int AgeClassificationId { get; set; }        
        public AgeClassification AgeClassification { get; set; }
    }
}