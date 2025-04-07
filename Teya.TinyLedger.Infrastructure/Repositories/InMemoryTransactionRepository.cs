using Teya.TinyLedger.Domain.Entities;
using Teya.TinyLedger.Domain.Interfaces;

namespace Teya.TinyLedger.Infrastructure.Repositories;

public class InMemoryTransactionRepository : ITransactionRepository
{
    private readonly List<Transaction> _transactions = new();

    public Task AddAsync(Transaction transaction)
    {
        _transactions.Add(transaction);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Transaction>> GetAllAsync()
    {
        return Task.FromResult((IReadOnlyList<Transaction>)_transactions.ToList());
    }
}