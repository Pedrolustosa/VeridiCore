namespace VeridiCore.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
