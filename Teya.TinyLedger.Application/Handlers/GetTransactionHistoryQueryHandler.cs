using Teya.TinyLedger.Application.DTOs;
using Teya.TinyLedger.Domain.Interfaces;

namespace Teya.TinyLedger.Application.Handlers;

public class GetTransactionHistoryQueryHandler
{
    private readonly ITransactionRepository _repository;

    public GetTransactionHistoryQueryHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TransactionDto>> Handle()
    {
        var transactions = await _repository.GetAllAsync();

        return transactions.Select(t => new TransactionDto(
            t.Id,
            t.Amount.Value,
            t.Type.ToString(),
            t.Timestamp));
    }
}