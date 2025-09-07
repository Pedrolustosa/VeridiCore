using VeridiCore.Domain.Entities;

namespace VeridiCore.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<Category?> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllByUserAsync(Guid userId);
    void Update(Category category);
    void Delete(Category category);
}