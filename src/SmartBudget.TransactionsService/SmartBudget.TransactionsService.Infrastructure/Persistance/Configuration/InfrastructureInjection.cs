using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBudget.TransactionsService.Domain.Interfaces;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Contexts;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Infrastructure.Persistance.Configuration
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrasctructure(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<TransactionDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
