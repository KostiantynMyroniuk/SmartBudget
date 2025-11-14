using SmartBudget.Gateway.DTOs.Transaction;
using SmartBudget.Gateway.Interfaces;
using SmartBudget.SharedContracts.Category;
using SmartBudget.SharedContracts.Transaction;

namespace SmartBudget.Gateway.Services
{
    public class TransactionAggregatorService : ITransactionAggregatorService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        private readonly string _transactionUrl;
        private readonly string _categoryUrl;

        public TransactionAggregatorService(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;

            _transactionUrl = _config["ServiceUrls:Transactions"] 
                ?? throw new InvalidOperationException("URL 'ServiceUrls:Transactions' не знайдено в конфігурації.");

            _categoryUrl = _config["ServiceUrls:Categories"]
                ?? throw new InvalidOperationException("URL 'ServiceUrls:Categories' не знайдено в конфігурації.");
        }

        public async Task<IEnumerable<EnrichedTransactionDto>> GetEnrichedTransactions(
            CancellationToken cancellationToken = default)
        {
            var client = _factory.CreateClient();


            try
            {
                var transactionsTask =
                    client.GetFromJsonAsync<List<TransactionDto>>(_transactionUrl, cancellationToken)!;

                var categoriesTask =
                    client.GetFromJsonAsync<List<CategoryDto>>(_categoryUrl, cancellationToken)!;

                await Task.WhenAll(transactionsTask, categoriesTask);


                var transactions = transactionsTask.Result ?? new List<TransactionDto>();

                var categories = categoriesTask.Result ?? new List<CategoryDto>();


                var categoriesMap = categories.ToDictionary(c => c.Id);

                var enrichedTransactions = transactions.Select(t =>
                {
                    categoriesMap.TryGetValue(t.CategoryId, out var category);

                    return new EnrichedTransactionDto
                    {
                        Id = t.Id,
                        Amount = t.Amount,
                        Date = t.Date,
                        Note = t.Note,
                        CategoryId = t.CategoryId,
                        CategoryName = category?.Name ?? "N/A"
                    };

                });

                return enrichedTransactions;
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<EnrichedTransactionDto>();
            }
            
        }
    }
}
