using Teya.TinyLedger.Domain.Enums;
using Teya.TinyLedger.Domain.ValueObjects;

namespace Teya.TinyLedger.Domain.Entities;

public class Ledger
{
    private readonly List<Transaction> _transactions;

    public Ledger(IEnumerable<Transaction> transactions)
    {
        _transactions = transactions.ToList();
    }

    public Money CalculateBalance()
    {
        return _transactions.Aggregate(
            Money.Zero,
            (acc, t) =>
                t.Type == TransactionType.Deposit
                    ? acc.Add(t.Amount)
                    : acc.Subtract(t.Amount));
    }
}