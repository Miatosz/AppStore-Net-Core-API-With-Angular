using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}