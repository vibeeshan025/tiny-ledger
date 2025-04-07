using Teya.TinyLedger.Application.DTOs;
using Teya.TinyLedger.Domain.Entities;
using Teya.TinyLedger.Domain.Interfaces;

namespace Teya.TinyLedger.Application.Handlers;

public class GetBalanceQueryHandler
{
    private readonly ITransactionRepository _repository;

    public GetBalanceQueryHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<BalanceDto> Handle()
    {
        var transactions = await _repository.GetAllAsync();
        var ledger = new Ledger(transactions);
        var balance = ledger.CalculateBalance();
        return new BalanceDto(balance.Value, balance.Currency);
    }
}