using Teya.TinyLedger.Application.Commands;
using Teya.TinyLedger.Application.DTOs;
using Teya.TinyLedger.Domain.Entities;
using Teya.TinyLedger.Domain.Enums;
using Teya.TinyLedger.Domain.Interfaces;
using Teya.TinyLedger.Domain.ValueObjects;

namespace Teya.TinyLedger.Application.Handlers;

public class RecordTransactionCommandHandler(ITransactionRepository repository)
{
    private readonly ITransactionRepository _repository = repository;

    public async Task<TransactionDto> Handle(RecordTransactionCommand command)
    {
        var type = Enum.Parse<TransactionType>(command.Type, true);
        var transaction = new Transaction(new Money(command.Amount), type, command.Description);
        await _repository.AddAsync(transaction);

        return new TransactionDto(transaction.Id, transaction.Amount.Value, transaction.Type.ToString(), transaction.Timestamp);
    }
}