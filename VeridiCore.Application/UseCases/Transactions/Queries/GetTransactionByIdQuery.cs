using MediatR;
using VeridiCore.Application.DTOs;

namespace VeridiCore.Application.UseCases.Transactions.Queries;

public record GetTransactionByIdQuery(
    Guid Id,
    Guid UserId
) : IRequest<TransactionDto?>;