namespace Teya.TinyLedger.Application.DTOs;

public record TransactionDto(
    Guid Id,
    decimal Amount,
    string Type,
    DateTime Timestamp);