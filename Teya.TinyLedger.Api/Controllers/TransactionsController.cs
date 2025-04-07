using Microsoft.AspNetCore.Mvc;
using Teya.TinyLedger.Api.Models;
using Teya.TinyLedger.Application.Commands;
using Teya.TinyLedger.Application.Interfaces;

namespace Teya.TinyLedger.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<ActionResult<TransactionResponse>> CreateTransaction(CreateTransactionRequest request)
    {
        var command = new RecordTransactionCommand(request.Amount, request.Type, request.Description);
        var dto = await _transactionService.RecordTransactionAsync(command);

        return Ok(new TransactionResponse
        {
            Id = dto.Id,
            Amount = dto.Amount,
            Type = dto.Type,
            Timestamp = dto.Timestamp
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetAll()
    {
        var history = await _transactionService.GetTransactionHistoryAsync();

        var response = history.Select(t => new TransactionResponse
        {
            Id = t.Id,
            Amount = t.Amount,
            Type = t.Type,
            Timestamp = t.Timestamp
        });

        return Ok(response);
    }
}