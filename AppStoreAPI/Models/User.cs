using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        
        public List<App> Apps { get; set; }
    }
}