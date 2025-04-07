using Microsoft.AspNetCore.Mvc;
using Teya.TinyLedger.Api.Models;
using Teya.TinyLedger.Application.Interfaces;

namespace Teya.TinyLedger.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BalanceController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public BalanceController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<ActionResult<BalanceResponse>> GetBalance()
    {
        var dto = await _transactionService.GetBalanceAsync();

        return Ok(new BalanceResponse
        {
            Balance = dto.Balance,
            Currency = dto.Currency
        });
    }
}