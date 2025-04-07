using Microsoft.Extensions.DependencyInjection;
using Teya.TinyLedger.Application.Handlers;
using Teya.TinyLedger.Application.Interfaces;
using Teya.TinyLedger.Application.Services;
using Teya.TinyLedger.Domain.Interfaces;
using Teya.TinyLedger.Infrastructure.Repositories;

namespace Teya.TinyLedger.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLedgerAppDependencies(this IServiceCollection services)
    {
        // Repositories
        services.AddSingleton<ITransactionRepository, InMemoryTransactionRepository>();

        // Application Services
        services.AddScoped<ITransactionService, TransactionService>();

        // Handlers
        services.AddScoped<RecordTransactionCommandHandler>();
        services.AddScoped<GetBalanceQueryHandler>();
        services.AddScoped<GetTransactionHistoryQueryHandler>();

        return services;
    }
}