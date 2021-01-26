using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Dtos.UpdateDtos
{
    public class DeveloperUpdateDto
    {
        [Required]
        public string Name { get; set; }

        public string CompanyName { get; set; }
    }
}