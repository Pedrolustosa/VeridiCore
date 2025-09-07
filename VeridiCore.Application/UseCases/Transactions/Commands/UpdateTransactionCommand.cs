using MediatR;
namespace VeridiCore.Application.UseCases.Transactions.Commands;

public record UpdateTransactionCommand(
    Guid Id,
    string Title,
    decimal Amount,
    DateTime PaidOrReceivedAt,
    Guid CategoryId,
    Guid UserId
) : IRequest<bool>;