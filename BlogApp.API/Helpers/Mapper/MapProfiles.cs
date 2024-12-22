using AutoMapper;
using BlogApp.API.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.API.Helpers.Mapper
{
    public class MapProfiles:Profile
    {
        public MapProfiles()
        {
            CreateMap<CreateCategoryDto, Category>();
        }

    }
}
