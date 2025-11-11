using SmartBudget.SharedContracts.Transaction;
using SmartBudget.TransactionsService.Application.Interfaces;
using SmartBudget.TransactionsService.Domain.Entities;
using SmartBudget.TransactionsService.Domain.Interfaces;
using SmartBudget.TransactionsService.Infrastructure.Persistence.Repositories;
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

        public async Task Add(TransactionDto transactionDto)
        {
            if (transactionDto.Amount == 0)
                throw new ArgumentException("Amount can`t be 0", nameof(transactionDto.Amount));

            await _repository.Add(transactionDto.MapToEntity());
        }

        public async Task Delete(int id)
        {
            var transaction = await _repository.GetById(id);

            if (transaction != null)
                await _repository.Delete(id);
            else
                throw new KeyNotFoundException($"Transaction with id: {id} not found");
        }

        public async Task<IEnumerable<TransactionDto>> GetAll()
        {
            var trans = await _repository.GetAll();

            return trans.MapToDto();
        }

        public async Task<TransactionDto?> GetById(int id)
        {
            var transaction = await _repository.GetById(id);

            if (transaction != null)
                return transaction.MapToDto();
            else
                throw new KeyNotFoundException($"Transaction with id: {id} not found");

        }
    }
}
