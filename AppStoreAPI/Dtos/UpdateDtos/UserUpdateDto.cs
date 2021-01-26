using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Dtos.UpdateDtos
{
    public class UserUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}