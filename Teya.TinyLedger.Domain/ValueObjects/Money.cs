namespace Teya.TinyLedger.Domain.ValueObjects;

public sealed class Money : IEquatable<Money>
{
    public decimal Value { get; }
    public string Currency { get; }

    public static readonly Money Zero = new(0);

    public Money(decimal value, string currency = "USD")
    {
        if (value < 0)
            throw new ArgumentException("Money cannot be negative");

        Value = value;
        Currency = currency;
    }

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Value + other.Value, Currency);
    }

    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Value - other.Value, Currency);
    }

    public Money Negate() => new(-Value, Currency);

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Currency mismatch");
    }

    public override bool Equals(object? obj) => Equals(obj as Money);
    public bool Equals(Money? other) =>
        other is not null && Value == other.Value && Currency == other.Currency;

    public override int GetHashCode() => HashCode.Combine(Value, Currency);
}