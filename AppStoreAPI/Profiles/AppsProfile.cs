using AppStoreAPI.Dtos;
using AppStoreAPI.Dtos.UpdateDtos;
using AppStoreAPI.Models;
using AutoMapper;

namespace AppStoreAPI.Profiles
{
    public class AppsProfile : Profile
    {
        public AppsProfile()
        {
            // GET Dtos
            CreateMap<App, GetAppsDto>();
            CreateMap<AgeClassification, GetAgeClassificationsDto>();
            CreateMap<Developer, GetDevelopersDto>();
            CreateMap<Platform, GetPlatformsDto>();
            CreateMap<User, GetUsersDto>();

            // POST Dtos
            CreateMap<AppCreateDto, App>();
            CreateMap<AgeClassificationCreateDto, AgeClassification>();
            CreateMap<DeveloperCreateDto, Developer>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<UserCreateDto, User>();

            // PUT Dtos

            CreateMap<AppUpdateDto, App>();
            // CreateMap<AgeUpdateCreateDto, AgeClassification>();
            CreateMap<DeveloperUpdateDto, Developer>();
            // CreateMap<PlatformUpdateDto, Platform>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<App, AppUpdateDto>();
            // CreateMap<AgeClassification, AgeUpdateCreateDto>();
            CreateMap<Developer, DeveloperUpdateDto>();
            // CreateMap<Platform, PlatformUpdateDto>();
            CreateMap<User, UserUpdateDto>();
        }   
    }
}