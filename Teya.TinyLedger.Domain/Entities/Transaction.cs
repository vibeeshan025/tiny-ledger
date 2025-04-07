using Teya.TinyLedger.Domain.Enums;
using Teya.TinyLedger.Domain.ValueObjects;

namespace Teya.TinyLedger.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Money Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public string? Description { get; private set; }
    public DateTime Timestamp { get; private set; }

    public Transaction(Money amount, TransactionType type, string? description)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Type = type;
        Description = description;
        Timestamp = DateTime.UtcNow;
    }
}