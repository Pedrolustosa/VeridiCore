using MediatR;
using VeridiCore.Domain.Enums;

namespace VeridiCore.Application.UseCases.Transactions.Commands;

public record CreateTransactionCommand(
    string Title,
    decimal Amount,
    CategoryType Type,
    DateTime PaidOrReceivedAt,
    Guid CategoryId,
    Guid UserId
) : IRequest<Guid>;