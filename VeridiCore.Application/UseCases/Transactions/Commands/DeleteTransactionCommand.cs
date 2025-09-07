using MediatR;

namespace VeridiCore.Application.UseCases.Transactions.Commands;

public record DeleteTransactionCommand(Guid Id, Guid UserId) : IRequest<bool>;