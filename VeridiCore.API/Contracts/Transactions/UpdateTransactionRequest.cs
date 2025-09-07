namespace VeridiCore.API.Contracts.Transactions
{
    public record UpdateTransactionRequest(string Title, decimal Amount, DateTime PaidOrReceivedAt, Guid CategoryId);

}
