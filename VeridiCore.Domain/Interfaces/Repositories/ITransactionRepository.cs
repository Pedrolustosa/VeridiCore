using VeridiCore.Domain.Entities;

namespace VeridiCore.Domain.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<Transaction?> GetByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetByPeriodAsync(Guid userId, DateTime startDate, DateTime endDate);
    void Update(Transaction transaction);
    void Delete(Transaction transaction);
}