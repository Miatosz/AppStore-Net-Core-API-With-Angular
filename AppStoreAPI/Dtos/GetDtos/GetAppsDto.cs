namespace AppStoreAPI.Dtos
{
    public class GetAppsDto
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateOfLastUpdate { get; set; }
        public float Price { get; set; }
        public string AppFileUrl {get; set;}
        public string AppImagePath {get; set;}
        public int NumberOfDownloads { get; set; }
        public string DeveloperName { get; set; }
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string AgeClassificationName { get; set; }

    }
}