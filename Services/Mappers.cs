using AutoMapper;
using Common.Dtos;
using Common.Dtos.ProductDTOs;
using Common.Dtos.UserDTOs;
using Common.Responses;
using Common.ViewModels.CategoryViewModels;
using Common.ViewModels.ProductViewModels;
using Common.ViewModels.UserViewModels;
using Models.Models.Categories;
using Models.Models.Products;
using Models.Models.SystemUsers;
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

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Result<User>, Result<UserDTO>>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Result<User>, Result<UserViewModel>>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Result<Product>, Result<ProductDTO>>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Result<Product>, Result<ProductViewModel>>().ReverseMap();
        }
    }
}
