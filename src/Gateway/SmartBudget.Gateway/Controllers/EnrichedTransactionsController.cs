using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.Gateway.Interfaces;

namespace SmartBudget.Gateway.Controllers
{
    [Route("api/enriched-transactions")]
    [ApiController]
    public class EnrichedTransactionsController : ControllerBase
    {
        private readonly ITransactionAggregatorService _aggregatorService;

        public EnrichedTransactionsController(ITransactionAggregatorService aggregatorService)
        {
            _aggregatorService = aggregatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrichedTransactions()
        {
            return Ok(await _aggregatorService.GetEnrichedTransactions());
        }
    }
}
