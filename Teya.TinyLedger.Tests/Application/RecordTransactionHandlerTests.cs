using Teya.TinyLedger.Application.Commands;
using Teya.TinyLedger.Application.Handlers;
using Teya.TinyLedger.Infrastructure.Repositories;

namespace Teya.TinyLedger.Tests.Application;

public class RecordTransactionHandlerTests
{
    [Fact]
    public async Task Should_Record_Deposit_Transaction()
    {
        var repo = new InMemoryTransactionRepository();
        var handler = new RecordTransactionCommandHandler(repo);

        var command = new RecordTransactionCommand(200.00m, "Deposit", "Test deposit");

        var result = await handler.Handle(command);

        Assert.Equal(200.00m, result.Amount);
        Assert.Equal("Deposit", result.Type);
        Assert.False(result.Id == Guid.Empty);
    }
}