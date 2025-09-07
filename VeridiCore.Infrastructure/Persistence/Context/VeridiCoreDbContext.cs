using System.Reflection;
using VeridiCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeridiCore.Infrastructure.Persistence.Context;

public class VeridiCoreDbContext(DbContextOptions<VeridiCoreDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}