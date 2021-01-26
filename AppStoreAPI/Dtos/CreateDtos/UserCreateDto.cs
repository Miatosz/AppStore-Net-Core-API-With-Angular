using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}