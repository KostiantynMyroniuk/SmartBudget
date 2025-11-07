using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBudget.TransactionsService.Application.Interfaces;
using SmartBudget.TransactionsService.Application.Services;
using SmartBudget.TransactionsService.Domain.Interfaces;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Contexts;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Application.Configuration
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
