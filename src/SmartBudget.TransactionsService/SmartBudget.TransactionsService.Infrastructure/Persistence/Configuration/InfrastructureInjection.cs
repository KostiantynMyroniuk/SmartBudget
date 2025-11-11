using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBudget.TransactionsService.Domain.Interfaces;
using SmartBudget.TransactionsService.Infrastructure.Persistence.Contexts;
using SmartBudget.TransactionsService.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Infrastructure.Persistence.Configuration
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrasctructureLayer(this IServiceCollection services, IConfiguration config)
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
