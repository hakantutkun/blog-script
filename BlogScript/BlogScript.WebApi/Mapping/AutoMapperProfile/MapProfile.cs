using AutoMapper;
using BlogScript.DTOs.DTOs.BlogDTOs;
using BlogScript.DTOs.DTOs.CategoryDTOs;
using BlogScript.Entities.Concrete;
using BlogScript.WebApi.Models;

namespace BlogScript.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog, BlogListDto>();

            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogAddModel>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

        }
    }
}
