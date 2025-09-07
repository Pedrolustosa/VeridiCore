using MediatR;
using VeridiCore.Application.DTOs;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Transactions.Queries;

public class GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionByIdQuery, TransactionDto?>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;

    public async Task<TransactionDto?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetByIdAsync(request.Id);
        if (transaction is null || transaction.UserId != request.UserId)
        {
            return null;
        }

        return new TransactionDto(
            transaction.Id,
            transaction.Title,
            transaction.Amount,
            transaction.Type.ToString(),
            transaction.PaidOrReceivedAt,
            transaction.CategoryId,
            transaction.Category.Name,
            transaction.CreatedAt
        );
    }
}