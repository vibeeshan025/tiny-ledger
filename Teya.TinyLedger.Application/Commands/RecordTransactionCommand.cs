namespace Teya.TinyLedger.Application.Commands;

public record RecordTransactionCommand(
    decimal Amount,
    string Type,
    string? Description);