using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Dtos
{
    public class PlatformCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}