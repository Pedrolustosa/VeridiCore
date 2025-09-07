using VeridiCore.Domain.Common;
using VeridiCore.Domain.Enums;

namespace VeridiCore.Domain.Entities;

public class Transaction : BaseEntity
{
    public string Title { get; private set; }
    public decimal Amount { get; private set; }
    public CategoryType Type { get; private set; }
    public DateTime PaidOrReceivedAt { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid UserId { get; private set; }

    public Category Category { get; private set; }

    private Transaction() { }

    public static Transaction Create(
        string title,
        decimal amount,
        CategoryType type,
        DateTime paidOrReceivedAt,
        Guid categoryId,
        Guid userId)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be a positive value.", nameof(amount));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        var transaction = new Transaction
        {
            Title = title,
            Amount = amount,
            Type = type,
            PaidOrReceivedAt = paidOrReceivedAt,
            CategoryId = categoryId,
            UserId = userId,
        };

        return transaction;
    }

    public void Update(string title, decimal amount, DateTime paidOrReceivedAt, Guid categoryId)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be a positive value.", nameof(amount));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        Title = title;
        Amount = amount;
        PaidOrReceivedAt = paidOrReceivedAt;
        CategoryId = categoryId;
        UpdatedAt = DateTime.UtcNow;
    }

    public virtual void Deactivate()
    {
        IsActive = false;
        DeletedAt = DateTime.UtcNow;
    }
}