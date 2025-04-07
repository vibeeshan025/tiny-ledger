using Teya.TinyLedger.Domain.Entities;

namespace Teya.TinyLedger.Domain.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<IReadOnlyList<Transaction>> GetAllAsync();
}