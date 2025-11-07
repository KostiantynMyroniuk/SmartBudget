using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBudget.CategoriesService.Application.Services;
using SmartBudget.CategoriesService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Application.Configuration
{
   public static class ApplicationInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
