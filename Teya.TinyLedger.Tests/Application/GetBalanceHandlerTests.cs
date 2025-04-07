using Teya.TinyLedger.Application.Handlers;
using Teya.TinyLedger.Domain.Entities;
using Teya.TinyLedger.Domain.Enums;
using Teya.TinyLedger.Domain.ValueObjects;
using Teya.TinyLedger.Infrastructure.Repositories;

namespace Teya.TinyLedger.Tests.Application;

public class GetBalanceHandlerTests
{
    [Fact]
    public async Task Should_Calculate_Correct_Balance()
    {
        var repo = new InMemoryTransactionRepository();
        var deposit = new Transaction(new Money(500), TransactionType.Deposit, "Salary");
        var withdrawal = new Transaction(new Money(100), TransactionType.Withdrawal, "Groceries");

        await repo.AddAsync(deposit);
        await repo.AddAsync(withdrawal);

        var handler = new GetBalanceQueryHandler(repo);

        var result = await handler.Handle();

        Assert.Equal(400.00m, result.Balance);
        Assert.Equal("USD", result.Currency);
    }
}