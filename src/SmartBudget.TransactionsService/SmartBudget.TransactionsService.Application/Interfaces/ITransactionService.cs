using SmartBudget.SharedContracts.Transaction;
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
        Task Add(TransactionDto transactionDto);
        Task Delete(int id);
        Task<IEnumerable<TransactionDto>> GetAll();
        Task<TransactionDto?> GetById(int id);
    }
}
