using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Teya.TinyLedger.Api;
using Teya.TinyLedger.Api.Models;

namespace Teya.TinyLedger.Tests.Api;

public class TransactionsE2ETests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TransactionsE2ETests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Add_And_Withdraw_Money_And_Return_Correct_Balance()
    {
        // 1. Deposit $500
        var depositRequest = new CreateTransactionRequest
        {
            Amount = 500,
            Type = "Deposit",
            Description = "Initial Deposit"
        };

        var depositResponse = await _client.PostAsJsonAsync("/api/transactions", depositRequest);
        depositResponse.EnsureSuccessStatusCode();

        // 2. Withdraw $200
        var withdrawalRequest = new CreateTransactionRequest
        {
            Amount = 200,
            Type = "Withdrawal",
            Description = "Groceries"
        };

        var withdrawResponse = await _client.PostAsJsonAsync("/api/transactions", withdrawalRequest);
        withdrawResponse.EnsureSuccessStatusCode();

        // 3. Check balance
        var balanceResponse = await _client.GetAsync("/api/balance");
        balanceResponse.EnsureSuccessStatusCode();

        var content = await balanceResponse.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);
        var balance = json.RootElement.GetProperty("balance").GetDecimal();

        Assert.Equal(300.00m, balance); // 500 - 200 = 300
    }
}