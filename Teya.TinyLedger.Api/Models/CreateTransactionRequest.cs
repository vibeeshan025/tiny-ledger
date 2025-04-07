using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Teya.TinyLedger.Api.Models;

public class CreateTransactionRequest
{
    [SwaggerSchema("Amount of the transaction", Format = "decimal")]
    [DefaultValue(100.0)]
    public decimal Amount { get; set; }

    [SwaggerSchema("Transaction type: Deposit or Withdrawal")]
    [DefaultValue("Deposit")]
    public string Type { get; set; }

    [SwaggerSchema("Optional description for the transaction")]
    [DefaultValue("Initial deposit")]
    public string? Description { get; set; }
}