using SmartBudget.TransactionsService.Application.DTOs;
using SmartBudget.TransactionsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Application.Services
{
    public static class TransactionMapper
    {
        public static TransactionDto MapToDto(this Transaction transaction)
        {
            var trans = new TransactionDto()
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Note = transaction.Note,
                Date = transaction.Date,

                CategoryId = transaction.CategoryId
            };

            return trans;
        }

        public static Transaction MapToEntity(this TransactionDto transactionDto)
        {
            var trans = new Transaction()
            {
                Id = transactionDto.Id,
                Amount = transactionDto.Amount,
                Note = transactionDto.Note,
                Date = transactionDto.Date,

                CategoryId = transactionDto.CategoryId
            };

            return trans;
        }

        public static IEnumerable<TransactionDto> MapToDto(this IEnumerable<Transaction> transactions)
        {
            return transactions.Select(x => x.MapToDto());
        }

        public static IEnumerable<Transaction> MapToEntity(this IEnumerable<TransactionDto> transactionsDto)
        {
            return transactionsDto.Select(x => x.MapToEntity());
        }
    }
}
