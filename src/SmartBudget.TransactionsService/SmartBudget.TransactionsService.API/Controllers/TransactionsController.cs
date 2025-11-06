using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.TransactionsService.Application.Interfaces;
using SmartBudget.TransactionsService.Domain.Entities;

namespace SmartBudget.TransactionsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetAll()
        {
            var trans = await _service.GetAll();
            return Ok(trans);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Transaction transaction)
        {
            await _service.Add(transaction);
            return Created();
        }

    }
}
