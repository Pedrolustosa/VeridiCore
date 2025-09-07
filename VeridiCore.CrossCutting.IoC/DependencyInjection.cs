using MediatR;
using Microsoft.EntityFrameworkCore; // Adicione este using
using Microsoft.Extensions.Configuration; // Adicione este using
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VeridiCore.Domain.Interfaces.UnitOfWork;
using VeridiCore.Domain.Interfaces.Repositories;
using VeridiCore.Infrastructure.Persistence.UoW;
using VeridiCore.Infrastructure.Persistence.Context;
using VeridiCore.Infrastructure.Persistence.Repositories;

namespace VeridiCore.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<VeridiCoreDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(VeridiCoreDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("VeridiCore.Application")));

        return services;
    }
}