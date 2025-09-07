using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeridiCore.Domain.Entities;

namespace VeridiCore.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(150);
        builder.Property(t => t.Amount).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(t => t.Category)
               .WithMany()
               .HasForeignKey(t => t.CategoryId)
               .IsRequired();

        builder.HasQueryFilter(t => t.IsActive);
    }
}