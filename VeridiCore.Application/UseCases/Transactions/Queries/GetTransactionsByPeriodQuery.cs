using MediatR;
using VeridiCore.Application.DTOs;

namespace VeridiCore.Application.UseCases.Transactions.Queries;

public record GetTransactionsByPeriodQuery(
    Guid UserId,
    DateTime StartDate,
    DateTime EndDate
) : IRequest<IEnumerable<TransactionDto>>;