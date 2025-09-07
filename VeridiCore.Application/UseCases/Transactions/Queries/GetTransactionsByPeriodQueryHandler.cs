using MediatR;
using VeridiCore.Application.DTOs;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Transactions.Queries;

public class GetTransactionsByPeriodQueryHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionsByPeriodQuery, IEnumerable<TransactionDto>>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;

    public async Task<IEnumerable<TransactionDto>> Handle(GetTransactionsByPeriodQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.GetByPeriodAsync(request.UserId, request.StartDate, request.EndDate);
        return transactions.Select(t => new TransactionDto(
            t.Id,
            t.Title,
            t.Amount,
            t.Type.ToString(),
            t.PaidOrReceivedAt,
            t.CategoryId,
            t.Category.Name,
            t.CreatedAt
        ));
    }
}