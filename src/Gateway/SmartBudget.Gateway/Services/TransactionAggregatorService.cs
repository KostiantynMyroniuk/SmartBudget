using SmartBudget.Gateway.DTOs.Transaction;
using SmartBudget.Gateway.Interfaces;

namespace SmartBudget.Gateway.Services
{
    public class TransactionAggregatorService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        private readonly string _transactionUrl;
        private readonly string _categoryUrl;

        public TransactionAggregatorService(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;

            _transactionUrl = _config["ServiceUrls:Transactions"];
            _categoryUrl = _config["ServiceUrls:Categories"];
        }

        
    }
}
