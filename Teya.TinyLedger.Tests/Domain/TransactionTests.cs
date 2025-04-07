using Teya.TinyLedger.Domain.Entities;
using Teya.TinyLedger.Domain.Enums;
using Teya.TinyLedger.Domain.ValueObjects;

namespace Teya.TinyLedger.Tests.Domain;

public class TransactionTests
{
    [Fact]
    public void Create_Deposit_Transaction_Should_Have_Correct_Values()
    {
        var amount = new Money(100.00m);
        var transaction = new Transaction(amount, TransactionType.Deposit, "Test");

        Assert.NotEqual(Guid.Empty, transaction.Id);
        Assert.Equal(TransactionType.Deposit, transaction.Type);
        Assert.Equal(100.00m, transaction.Amount.Value);
        Assert.Equal("Test", transaction.Description);
        Assert.True((DateTime.UtcNow - transaction.Timestamp).TotalSeconds < 1);
    }
}