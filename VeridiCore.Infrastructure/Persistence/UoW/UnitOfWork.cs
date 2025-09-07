using VeridiCore.Domain.Interfaces.UnitOfWork;
using VeridiCore.Infrastructure.Persistence.Context;

namespace VeridiCore.Infrastructure.Persistence.UoW;

public class UnitOfWork(VeridiCoreDbContext context) : IUnitOfWork
{
    private readonly VeridiCoreDbContext _context = context;

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}