using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBudget.CategoriesService.Domain.Interfaces;
using SmartBudget.CategoriesService.Infrastructure.Persistence.Contexts;
using SmartBudget.CategoriesService.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Infrastructure.Persistence.Configuration
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<CategoryDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
