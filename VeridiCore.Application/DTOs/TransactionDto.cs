namespace VeridiCore.Application.DTOs;

public record TransactionDto(
    Guid Id,
    string Title,
    decimal Amount,
    string Type,
    DateTime PaidOrReceivedAt,
    Guid CategoryId,
    string CategoryName,
    DateTime CreatedAt
);