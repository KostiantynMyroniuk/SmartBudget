using Microsoft.EntityFrameworkCore;
using SmartBudget.TransactionsService.Domain.Entities;
using SmartBudget.TransactionsService.Domain.Interfaces;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.TransactionsService.Infrastructure.Persistance.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext context) => _context = context;
         
        public async Task Add(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            _context.Transactions.Remove(transaction!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }
    }
}
