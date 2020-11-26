
using Common.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using Models.Models.Categories;
using Models.Models.Products;
using Models.Models.SystemUsers;
using Models.Service;
using Repository;
using Services;
using Services.Setup;

namespace HousingColonyPOS
{
    public static class DependencyServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
     

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryManager, CategoryManager>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUsersManager, UserManager>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductManager, ProductManager>();
            return services;
        }
    }
}
