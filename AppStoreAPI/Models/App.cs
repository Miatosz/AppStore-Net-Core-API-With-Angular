using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppStoreAPI.Models
{
    public class App
    {
        [Key]
        public int Id { get; set; }

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

        [Required]
        public string AppFileUrl {get; set;}

        public string AppImagePath {get; set;}

        public int NumberOfDownloads { get; set; }

        public int? DeveloperId { get; set; }
        
        [ForeignKey("DeveloperId")]
        public Developer Developer { get; set; }

        public int? PlatformId { get; set; }

        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }

        public int? AgeClassificationId { get; set; }
        
        [ForeignKey("AgeClassificationId")]
        public AgeClassification AgeClassification { get; set; }

    }
}