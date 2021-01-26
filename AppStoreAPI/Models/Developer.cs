using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStoreAPI.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CompanyName { get; set; }

        //public List<App> Apps { get; set; }
    }
}