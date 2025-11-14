using SmartBudget.Gateway.DTOs.Transaction;

namespace SmartBudget.Gateway.Interfaces
{
    public interface ITransactionAggregatorService
    {
        Task<IEnumerable<EnrichedTransactionDto>> GetEnrichedTransactions(CancellationToken cancellationToken = default);
    }
}
