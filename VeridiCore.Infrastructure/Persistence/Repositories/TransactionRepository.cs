using Microsoft.EntityFrameworkCore;
using VeridiCore.Domain.Entities;
using VeridiCore.Domain.Interfaces.Repositories;
using VeridiCore.Infrastructure.Persistence.Context;

namespace VeridiCore.Infrastructure.Persistence.Repositories;

public class TransactionRepository(VeridiCoreDbContext context) : ITransactionRepository
{
    private readonly VeridiCoreDbContext _context = context;

    public async Task AddAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _context.Transactions
            .Include(t => t.Category)
            .SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Transaction>> GetByPeriodAsync(Guid userId, DateTime startDate, DateTime endDate)
    {
        return await _context.Transactions
            .Include(t => t.Category)
            .Where(t => t.UserId == userId &&
                         t.PaidOrReceivedAt >= startDate &&
                         t.PaidOrReceivedAt <= endDate)
            .OrderByDescending(t => t.PaidOrReceivedAt)
            .ToListAsync();
    }

    public void Update(Transaction transaction) => _context.Update(transaction);
    public void Delete(Transaction transaction) => _context.Remove(transaction);
}