namespace Teya.TinyLedger.Application.DTOs;

public record BalanceDto(
    decimal Balance,
    string Currency);