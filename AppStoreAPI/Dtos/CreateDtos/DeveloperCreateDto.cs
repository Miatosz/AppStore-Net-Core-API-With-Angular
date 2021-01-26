using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Dtos
{
    public class DeveloperCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string CompanyName { get; set; }

    }
}