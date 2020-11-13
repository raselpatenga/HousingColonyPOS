﻿
using Common.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using Models.Models.Categories;
using Models.Service;
using Repository;

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

            return services;
        }
    }
}
