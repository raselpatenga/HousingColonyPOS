using AutoMapper;
using Common.Dtos;
using Common.Responses;
using Common.ViewModels.CategoryViewModels;
using Models.Models.Categories;
using System.Linq;

namespace Services
{

    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Result<Category>, Result<CategoryDTO>>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Result<Category>, Result<CategoryViewModel>>().ReverseMap();
        }
    }
}
