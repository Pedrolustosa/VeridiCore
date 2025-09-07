using VeridiCore.Domain.Enums;

namespace VeridiCore.API.Contracts.Transactions
{
    public record CreateTransactionRequest(
        string Title,
        decimal Amount,
        CategoryType Type,
        DateTime PaidOrReceivedAt,
        Guid CategoryId
    );
}