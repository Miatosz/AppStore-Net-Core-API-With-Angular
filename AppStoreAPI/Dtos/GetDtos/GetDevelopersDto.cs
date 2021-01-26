using System.Collections.Generic;
using AppStoreAPI.Models;

namespace AppStoreAPI.Dtos
{
    public class GetDevelopersDto
    {
        public string Name { get; set; }

        public string CompanyName { get; set; }

        public List<App> Apps { get; set; }
    }
}