using Teya.TinyLedger.Application.Commands;
using Teya.TinyLedger.Application.DTOs;

namespace Teya.TinyLedger.Application.Interfaces;

public interface ITransactionService
{
    Task<TransactionDto> RecordTransactionAsync(RecordTransactionCommand command);
    Task<BalanceDto> GetBalanceAsync();
    Task<IEnumerable<TransactionDto>> GetTransactionHistoryAsync();
}