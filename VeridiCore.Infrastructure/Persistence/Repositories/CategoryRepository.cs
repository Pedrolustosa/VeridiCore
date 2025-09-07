using Microsoft.EntityFrameworkCore;
using VeridiCore.Domain.Entities;
using VeridiCore.Domain.Interfaces.Repositories;
using VeridiCore.Infrastructure.Persistence.Context;

namespace VeridiCore.Infrastructure.Persistence.Repositories;

public class CategoryRepository(VeridiCoreDbContext context) : ICategoryRepository
{
    private readonly VeridiCoreDbContext _context = context;

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id && c.IsActive);
    }

    public async Task<IEnumerable<Category>> GetAllByUserAsync(Guid userId)
    {
        return await _context.Categories
            .Where(c => c.UserId == userId && c.IsActive)
            .ToListAsync();
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }

    public void Delete(Category category)
    {
        _context.Categories.Update(category);
    }
}