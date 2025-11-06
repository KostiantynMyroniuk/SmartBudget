using SmartBudget.TransactionsService.Application.Interfaces;
using SmartBudget.TransactionsService.Domain.Entities;
using SmartBudget.TransactionsService.Domain.Interfaces;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Transaction transaction)
        {

            if (transaction.Amount == 0)
                throw new ArgumentException("Amount can`t be 0", nameof(transaction.Amount));

            await _repository.Add(transaction);
        }

        public async Task Delete(int id)
        {
            var transaction = await _repository.GetById(id);

            if (transaction != null)
                await _repository.Delete(id);
            else
                throw new KeyNotFoundException($"Transaction with id: {id} not found");
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Transaction?> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
