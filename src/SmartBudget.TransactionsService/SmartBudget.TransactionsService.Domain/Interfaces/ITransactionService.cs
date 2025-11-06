using SmartBudget.TransactionsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Application.Interfaces
{
    public interface ITransactionService
    {
        Task Add(Transaction transaction);
        Task Delete(int id);
        Task<IEnumerable<Transaction>> GetAll();
        Task<Transaction?> GetById(int id);
    }
}
