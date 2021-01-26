using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Dtos
{
    public class AgeClassificationCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}