using System.Collections.Generic;
using AppStoreAPI.Models;

namespace AppStoreAPI.Dtos
{
    public class GetUsersDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }        
        public List<App> Apps { get; set; }
    }
}