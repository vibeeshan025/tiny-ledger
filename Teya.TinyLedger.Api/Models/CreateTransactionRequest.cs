namespace Teya.TinyLedger.Api.Models;

public class CreateTransactionRequest
{
    public decimal Amount { get; set; }
    public string Type { get; set; } = "Deposit"; // Deposit or Withdrawal
    public string? Description { get; set; }
}