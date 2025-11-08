namespace SmartBudget.Gateway.DTOs.Transaction
{
    public class EnrichedTransactionDto
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
