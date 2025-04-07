using Teya.TinyLedger.Application.Commands;
using Teya.TinyLedger.Application.DTOs;
using Teya.TinyLedger.Application.Handlers;
using Teya.TinyLedger.Application.Interfaces;

namespace Teya.TinyLedger.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly RecordTransactionCommandHandler _recordHandler;
    private readonly GetBalanceQueryHandler _balanceHandler;
    private readonly GetTransactionHistoryQueryHandler _historyHandler;

    public TransactionService(
        RecordTransactionCommandHandler recordHandler,
        GetBalanceQueryHandler balanceHandler,
        GetTransactionHistoryQueryHandler historyHandler)
    {
        _recordHandler = recordHandler;
        _balanceHandler = balanceHandler;
        _historyHandler = historyHandler;
    }

    public Task<TransactionDto> RecordTransactionAsync(RecordTransactionCommand command)
        => _recordHandler.Handle(command);

    public Task<BalanceDto> GetBalanceAsync()
        => _balanceHandler.Handle();

    public Task<IEnumerable<TransactionDto>> GetTransactionHistoryAsync()
        => _historyHandler.Handle();
}